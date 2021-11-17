//
// Copyright: (c) Allplan Infrastructure 2021
// MainWindow.xaml.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Windows;

namespace BridgeToolsTest
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Clear event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPropGridClear( object sender, RoutedEventArgs e )
		{
			propGrid.Clear();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Add properties event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPropGridOpen( object sender, RoutedEventArgs e )
		{
			Test.Test.Open( propGrid.Root );
		}
	}
}
