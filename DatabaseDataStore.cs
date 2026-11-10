using System;
using System.Collections.Generic;

namespace OOP10FEXLab
{
	public class DatabaseDataStore : IDataStore
	{
		private const string ConnectionString = "PASTE_THE_CONNECTION_STRING";
		
		public List<MealPackage> LoadMeals()
		
			throw new NotImplementedException("DatabaseDataStore.LoadMeals: paste the provided connection/query code.");
	}

	public void SaveTransaction(Order order)
		{
            throw new NotImplementedException("DatabaseDataStore.SaveTransaction: paste the provided insert code.");
        }

		public interface GetLastOrderNumber()
	{
		throw new NotImplementedException("DatabaseDataStore.GetLastOrderNumber: paste the provided query code.");
	    }

    }
}
