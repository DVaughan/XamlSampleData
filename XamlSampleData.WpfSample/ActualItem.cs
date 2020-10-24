using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamlSampleData
{
	public class ActualItem : INotifyPropertyChanged
	{
		public string Name => "test name";
		public string Country => "test country";
		public int Alt => 500;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}