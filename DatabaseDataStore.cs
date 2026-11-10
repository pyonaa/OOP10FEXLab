using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;

namespace OOP10FEXLab
{
  
    public class DatabaseDataStore : IDataStore
    {
      
        private const string ConnectionString =
            "server=172.16.24.11;port=3306;database=fastfooddb;uid=root;pwd=;";

        private const string SelectPackages = "SELECT * FROM package_tbl";
        private const string InsertTransaction =
            "INSERT INTO transactions_tbl (package_name, transaction_date) VALUES (@pkg, @date)";

       
        private readonly TextFileDataStore localLog;

        public DatabaseDataStore(TextFileDataStore localLog)
        {
            if (localLog == null) throw new ArgumentNullException("localLog");
            this.localLog = localLog;
        }

        public string SourceName
        {
            get { return "MySQL " + DatabaseName(); }
        }

       
        public List<MealPackage> LoadMeals()
        {
      
            Dictionary<string, MealPackage> extraDetails = LoadExtraDetails();
            List<MealPackage> meals = new List<MealPackage>();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(SelectPackages, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> row = ReadRow(reader);

                        string name = Text(row, "package_name", "name");
                        if (string.IsNullOrWhiteSpace(name)) continue;

                        MealPackage extra;
                        extraDetails.TryGetValue(name.Trim(), out extra);

                        string code = Text(row, "package_id", "id", "code");
                        if (code == null) code = extra != null ? extra.Code : (meals.Count + 1).ToString();
                        if (code.All(char.IsDigit)) code = "P" + code;

                        string category = Text(row, "category", "package_category", "type");
                        if (category == null) category = extra != null ? extra.Category : "Package Meals";

                        string description = Text(row, "description", "package_description", "details");
                        if (description == null) description = extra != null ? extra.Description : "";

                        decimal? price = Number(row, "price", "package_price", "amount", "cost");
                        if (price == null) price = extra != null ? extra.Price : 0m;

                        meals.Add(new MealPackage(code, category, name, description, price.Value));
                    }
                }
            }
            return meals;
        }


        public void SaveTransaction(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    foreach (CartItem item in order.Items)
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(InsertTransaction, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@pkg", item.Meal.Name);
                                cmd.Parameters.AddWithValue("@date", order.OrderedAt);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    tran.Commit(); 
                }
            }

           
            try
            {
                localLog.SaveTransaction(order);
            }
            catch (IOException)
            {
            }
        }

        public int GetLastOrderNumber()
        {
            return localLog.GetLastOrderNumber();
        }

     

        private Dictionary<string, MealPackage> LoadExtraDetails()
        {
            Dictionary<string, MealPackage> details = new Dictionary<string, MealPackage>(StringComparer.OrdinalIgnoreCase);
            try
            {
                foreach (MealPackage meal in localLog.LoadMeals()) details[meal.Name] = meal;
            }
            catch (Exception)
            {
                
            }
            return details;
        }

        private static Dictionary<string, object> ReadRow(MySqlDataReader reader)
        {
            Dictionary<string, object> row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < reader.FieldCount; i++)
            {
                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
            }
            return row;
        }

        private static string Text(Dictionary<string, object> row, params string[] columns)
        {
            foreach (string column in columns)
            {
                object value;
                if (row.TryGetValue(column, out value) && value != null)
                {
                    string text = Convert.ToString(value, CultureInfo.InvariantCulture).Trim();
                    if (text.Length > 0) return text;
                }
            }
            return null;
        }

        private static decimal? Number(Dictionary<string, object> row, params string[] columns)
        {
            foreach (string column in columns)
            {
                object value;
                if (row.TryGetValue(column, out value) && value != null)
                {
                    try
                    {
                        return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
            return null;
        }

        private static string DatabaseName()
        {
            foreach (string part in ConnectionString.Split(';'))
            {
                string[] pair = part.Split('=');
                if (pair.Length == 2 && pair[0].Trim().Equals("database", StringComparison.OrdinalIgnoreCase))
                {
                    return pair[1].Trim();
                }
            }
            return "database";
        }
    }
}
