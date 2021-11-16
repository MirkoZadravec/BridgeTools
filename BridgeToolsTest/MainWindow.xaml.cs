using System.Windows;

namespace BridgeToolsTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnPropGridClear( object sender, RoutedEventArgs e )
		{
			propGrid.Clear();
		}

		private void OnPropGridOpen( object sender, RoutedEventArgs e )
		{
			Test.Open( propGrid );
		}
	}
}
