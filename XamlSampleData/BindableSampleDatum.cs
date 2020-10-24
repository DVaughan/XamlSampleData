using System;
using System.Dynamic;
using System.Reflection;

namespace XamlSampleData
{
	class BindableSampleDatum : DynamicObject, IDynamicMetaObjectProvider
	{
		readonly SampleDataMotif motif;
		ISampleDatum Instance { get; set; }

		public BindableSampleDatum(SampleDataMotif motif)
		{
			this.motif = motif;

			switch (motif)
			{
				case SampleDataMotif.People:
					Instance = PeopleValues.GetNextItem();
					break;
				case SampleDataMotif.Cities:
					Instance = CityValues.GetNextItem();
					break;
				default:
					throw new ArgumentOutOfRangeException("Unknown motif " + motif);
			}
		}

		/// <inheritdoc />
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = null;

			if (TryGetPropertyValue(Instance, binder.Name, out result))
			{
				return true;
			}

			result = Instance.GetNextProperty();

			return true;
		}

		bool TryGetPropertyValue(object instance, string propertyName, out object result)
		{
			result = null;

			try
			{
				PropertyInfo property = instance.GetType().GetProperty(propertyName);
				if (property == null)
				{
					return false;
				}

				result = property.GetValue(instance, null);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	public interface ISampleDatum
	{
		object GetNextProperty();
	}
}
