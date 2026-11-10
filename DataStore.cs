using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace OOP10FEXLab
{

    public interface IDataStore
    {
        string SourceName { get; }
        List<MealPackage> LoadMeals();
        void SaveTransaction(Order order);
        int GetLastOrderNumber();
    }

 
    public class TextFileDataStore : IDataStore
    {
        private const char Separator = '|';
        private const string TransactionHeader = "OrderNo|DateTime|Dining|Payment|Items|Total";

        private readonly string mealsPath;
        private readonly string transactionsPath;
        private readonly Encoding encoding = new UTF8Encoding(false);

        public TextFileDataStore(string folder)
        {
            Directory.CreateDirectory(folder);
            mealsPath = Path.Combine(folder, "meals.txt");
            transactionsPath = Path.Combine(folder, "transactions.txt");
        }

        public string SourceName { get { return "Notepad files (meals.txt)"; } }
        public string MealsPath { get { return mealsPath; } }
        public string TransactionsPath { get { return transactionsPath; } }


        public List<MealPackage> LoadMeals()
        {
            if (!File.Exists(mealsPath))
            {
                throw new FileNotFoundException(
                    "meals.txt was not found here:\n" + mealsPath +
                    "\n\nIn Solution Explorer, click meals.txt > Properties > " +
                    "Copy to Output Directory = Copy if newer, then run again.");
            }

            List<MealPackage> meals = new List<MealPackage>();
            string[] lines = File.ReadAllLines(mealsPath, encoding);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.Length == 0 || line.StartsWith("#")) continue;

                string[] parts = line.Split(Separator);
                if (parts.Length != 5)
                {
                    throw new FormatException(string.Format(
                        "meals.txt line {0} needs 5 parts (Code|Category|Name|Description|Price):\n{1}", i + 1, line));
                }

                decimal price;
                if (!decimal.TryParse(parts[4].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out price))
                {
                    throw new FormatException(string.Format(
                        "meals.txt line {0} has an invalid price: {1}", i + 1, parts[4]));
                }

                meals.Add(new MealPackage(parts[0], parts[1], parts[2], parts[3], price));
            }

            var duplicate = meals.GroupBy(m => m.Code, StringComparer.OrdinalIgnoreCase)
                                 .FirstOrDefault(g => g.Count() > 1);
            if (duplicate != null)
            {
                throw new FormatException("meals.txt uses the code " + duplicate.Key + " more than once.");
            }

            return meals;
        }


        public void SaveTransaction(Order order)
        {
            bool isNewFile = !File.Exists(transactionsPath);

            string items = string.Join("; ", order.Items.Select(i => string.Format(
                CultureInfo.InvariantCulture, "{0}x {1} [{2}] @ {3:0.00}",
                i.Quantity, i.Meal.Name, i.Meal.Code, i.Meal.Price)));

            string record = string.Join(Separator.ToString(), new[]
            {
                order.OrderNumber.ToString(CultureInfo.InvariantCulture),
                order.OrderedAt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                order.Dining.ToDisplay(),
                order.Payment.ToDisplay(),
                items,
                order.Total.ToString("0.00", CultureInfo.InvariantCulture)
            });

            using (StreamWriter writer = new StreamWriter(transactionsPath, true, encoding))
            {
                if (isNewFile) writer.WriteLine(TransactionHeader);
                writer.WriteLine(record);
            }
        }

   
        public int GetLastOrderNumber()
        {
            int last = 0;
            if (!File.Exists(transactionsPath)) return last;

            foreach (string line in File.ReadAllLines(transactionsPath, encoding))
            {
                int pipe = line.IndexOf(Separator);
                if (pipe <= 0) continue;

                int number;
                if (int.TryParse(line.Substring(0, pipe), out number) && number > last)
                {
                    last = number;
                }
            }
            return last;
        }
    }
}
