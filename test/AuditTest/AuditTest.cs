using Audit;
using System;
using System.Collections.Generic;
using Xunit;

namespace AuditTest
{
	public class AuditTest
	{
		private readonly Building buildingOne;
		private readonly Building buildingTwo;
		private readonly Building buildingThree;

		public AuditTest ()
		{
			buildingOne = new Building { Type = BuildingType.HOUSE, Colour = "Blue", CreatedDate = new DateTime (2000, 5, 5), ModifiedDate = new DateTime (2000, 5, 5), Number = 5, Owner = "Josh", PriceOfPurchase = 500 };
			buildingTwo = new Building { Type = BuildingType.HOUSE, Colour = "Blue", CreatedDate = new DateTime (2000, 5, 5), ModifiedDate = new DateTime (2000, 5, 5), Number = 8, Owner = "Josh", PriceOfPurchase = 7000 };
			buildingThree = new Building { Type = BuildingType.WAREHOUSE, Colour = "Brick", CreatedDate = new DateTime (1993, 4, 8), ModifiedDate = new DateTime (2004, 8, 13), Number = 77, Owner = "Jane", PriceOfPurchase = 20000 };
		}

		[Fact]
		public void NoDifference ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingOne);
			Assert.Empty (differences);
		}

		[Fact]
		public void TwoDifference ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingTwo);
			Assert.True (differences.Count == 2);
		}

		[Fact]
		public void NumberDifference ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingTwo);
			Assert.True (differences.Exists (item => item.PropertyName == "Number"));
		}

		[Fact]
		public void PropertyNameHasFormatted ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingTwo);
			Assert.False (differences.Exists (item => item.PropertyName == "PriceOfPurchase"));
		}

		[Fact]
		public void PropertyNameCorrectFormatting ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingTwo);
			Assert.True (differences.Exists (item => item.PropertyName == "Price Of Purchase"));
		}

		[Fact]
		public void BuildingTypeDifference()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingThree);
			Assert.True (differences.Exists (item => item.PropertyName == "Type"));
		}

		[Fact]
		public void CreatedDateDifference ()
		{
			List<Difference> differences = Audit.Audit.CompareProperties (buildingOne, buildingThree);
			Assert.True (differences.Exists (item => item.PropertyName == "Created Date"));
		}
	}
}