using System;
using System.Reflection;
using System.Collections.Generic;

namespace Audit
{
	public static class Audit
	{
		public static List<Difference> CompareProperties (object first, object second)
		{
			if (first == null || second == null) {
				throw new ArgumentNullException ();
			}

			Type objectType = first.GetType ();
			if (objectType != second.GetType ()) {
				throw new Exception ("Cannot compare objects of different types.");
			}

			List<Difference> differences = new List<Difference> ();
			foreach (PropertyInfo objectProperty in objectType.GetProperties ()) 
			{
				object firstValue = objectProperty.GetValue (first);
				object secondValue = objectProperty.GetValue (second);

				// Need to use .Equals as we're comparing the objects.
				if (!firstValue.Equals(secondValue)) 
				{
					differences.Add (new Difference {
						PropertyName = FormatPropertyName(objectProperty.Name),
						ValueFirst = firstValue,
						ValueSecond = secondValue
					});
				}
			}

			return differences;
		}

		private static string FormatPropertyName (string name)
		{
			string formattedName = "";
			formattedName += char.ToUpper (name [0]);

			for (int i = 1; i < name.Length; i++) {
				if (char.IsUpper (name [i])) {
					formattedName += " ";
				}
				formattedName += name [i];
			}

			return formattedName;
		}
	}
}

