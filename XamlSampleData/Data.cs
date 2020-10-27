using System;

namespace XamlSampleData
{
	public class Person : ISampleDatum
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }

		public Person(string firstName, string lastName, string phoneNumber)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PhoneNumber = phoneNumber;
		}

		int previousProperty;

		public object GetNextProperty()
		{
			if (previousProperty > 2)
			{
				previousProperty = 0;
			}

			switch (previousProperty++)
			{
				case 0:
					return FirstName;
				case 1:
					return LastName;
				case 2:
					return PhoneNumber;
			}

			throw new InvalidOperationException();
		}
	}

	public class City : ISampleDatum
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public int Altitude { get; set; }

		public City(string name, string country, int altitude)
		{
			this.Name = name;
			this.Country = country;
			this.Altitude = altitude;
		}

		int previousProperty;

		public object GetNextProperty()
		{
			if (previousProperty > 2)
			{
				previousProperty = 0;
			}

			switch (previousProperty++)
			{
				case 0:
					return Name;
				case 1:
					return Country;
				case 2:
					return Altitude;
			}

			throw new InvalidOperationException();
		}
	}

	public class PeopleValues
	{
		public static Person[] Items = new[]
		{
			new Person("William", "Shakespeare", "392948722"),
			new Person("James", "Dean", "4398292933"),
			new Person("Marilyn", "Monroe", "246677433"),
			new Person("James", "Kirk", "14920192"),
			new Person("Jean-Luc", "Picard", "94922192"),
		};

		static int previousIndex;

		public static Person GetNextItem()
		{
			if (previousIndex >= Items.Length)
			{
				previousIndex = 0;
			}

			return Items[previousIndex++];
		}
	}

	public class CityValues
	{
		public static City[] Items = new[]
		{
			new City("Prague", "Czech Republic", 177),
			new City("Seattle", "United States of America", 53),
			new City("London", "England", 11),
			new City("Canberra", "Australia", 577),
			new City("Zurich", "Switzerland", 408),
		};

		static int previousIndex;

		public static City GetNextItem()
		{
			if (previousIndex >= Items.Length)
			{
				previousIndex = 0;
			}

			return Items[previousIndex++];
		}
	}
}