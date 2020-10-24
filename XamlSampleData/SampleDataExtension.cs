using System;
using System.Collections.ObjectModel;
using System.Windows.Markup;

namespace XamlSampleData
{
	public enum SampleDataMotif
	{
		Cities,
		People
	}

    public class SampleDataExtension : MarkupExtension
	{
		public SampleDataMotif Motif { get; set; } = SampleDataMotif.Cities;

		public int ItemCount { get; set; } = 5;

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var result = new ObservableCollection<object>();

			for (int i = 0; i < ItemCount; i++)
			{
				var datum = new BindableSampleDatum(Motif);
				result.Add(datum);
			}

			return result;
		}
	}
}
