using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamlSampleData.WpfSample
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<ActualItem> Items1 { get; } = new ObservableCollection<ActualItem>()
																		{
																			new ActualItem(), new ActualItem()
																		};




		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
