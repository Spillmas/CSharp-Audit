using System;

namespace Audit
{
	public enum BuildingType
	{
		FLAT,
		SHOP,
		WAREHOUSE,
		HOUSE,
		GARAGE
	}

	public class Building
	{
		public int Number { get; set; }
		public BuildingType Type { get; set; }
		public string Owner { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public double PriceOfPurchase { get; set; }
		private double PriceToSell { get; set; }

		public string Colour;
	}
}

