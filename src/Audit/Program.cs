using System;
using System.Collections.Generic;

namespace Audit
{
	public class Program
	{
		public static void Main (string [] args)
		{
			Building buildingOne = new Building { Type = BuildingType.HOUSE, Colour = "Blue", CreatedDate = new DateTime (2000, 5, 5), ModifiedDate = new DateTime (2000, 5, 5), Number = 5, Owner = "Josh", PriceOfPurchase = 500 };
		 	Building buildingTwo = new Building { Type = BuildingType.HOUSE, Colour = "Blue", CreatedDate = new DateTime (2000, 5, 5), ModifiedDate = new DateTime (2000, 5, 5), Number = 8, Owner = "Josh", PriceOfPurchase = 7000 };
			Building buildingThree = new Building { Type = BuildingType.WAREHOUSE, Colour = "Brick", CreatedDate = new DateTime (1993, 4, 8), ModifiedDate = new DateTime (2004, 8, 13), Number = 77, Owner = "Jane", PriceOfPurchase = 20000 };

			PrintCompare (buildingOne, buildingTwo);
			PrintContinue ();

			PrintCompare (buildingOne, buildingThree);
			Console.WriteLine ("*Note that 'Colour' is not in the list of differences. This is because 'Colour' is a field. The code could be expanded to include fields within the comparison.");
			PrintContinue ();

			PrintCompare (buildingThree, buildingTwo);
			Console.WriteLine ("*Note that 'Colour' is not in the list of differences. This is because 'Colour' is a field. The code could be expanded to include fields within the comparison.");
			PrintContinue ();
		}

		public static void PrintBuildings (Building one, Building two)
		{
			Console.WriteLine ("{21,17} {22,20} {23,20}\n" +
			                  "{14,17} {0,20} {1,20}\n" +
			                  "{15,17} {2,20} {3,20}\n" +
							  "{16,17} {4,20} {5,20}\n" +
							  "{17,17} {6,20} {7,20}\n" +
							  "{18,17} {8,20} {9,20}\n" +
							  "{19,17} {10,20} {11,20}\n" +
							  "{20,17} {12,20} {13,20}",
							  one.Type, two.Type,
							  one.Colour, two.Colour,
							  one.CreatedDate.Date, two.CreatedDate.Date,
							  one.ModifiedDate.Date, two.ModifiedDate.Date,
							  one.Number, two.Number,
							  one.Owner, two.Owner,
							  one.PriceOfPurchase, two.PriceOfPurchase,
							   "Type", 
			                   "Colour",
			                   "Create Date", 
			                   "Modified Date", 
			                   "Number", 
			                   "Owner", 
			                   "Price Of Purchase",
			                   "Object",
			                   "One",
			                   "Two"
							  );
		}

		public static void PrintDifferences (List<Difference> differences)
		{
			Console.WriteLine ("There are {0} different properties:", differences.Count);
			foreach (Difference diff in differences) 
			{
				Console.WriteLine ("{0,17} {1,20} {2,20}",
								   diff.PropertyName, diff.ValueFirst, diff.ValueSecond);
			}
		}

		public static void PrintCompare (Building one, Building two)
		{
			Console.WriteLine ("Comparing objects One and Two:");
			PrintBuildings (one, two);
			Console.WriteLine ();
			PrintDifferences (Audit.CompareProperties (one, two));
			Console.WriteLine ();
		}

		public static void PrintContinue ()
		{
			Console.WriteLine ("Press any key to continue...");
			Console.ReadKey (true);
			Console.Clear ();
		}
	}
}
