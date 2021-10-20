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
			var vm = new ViewModelPiers() { Project = "Project 1" };

			// container at level 1
			var catPiers = propGrid.AddCategory( "Piers", true );
			{
				// property at level 1 ( key/value pair )
				catPiers.AddTextProperty(
					"Project",
					// bindings
					vm,
					nameof( vm.Project ) );

				// container at level 2 (with checkbox)
				var catPier1 = catPiers.AddCheckCategory(
					"Pier 1",
					true,
					// bindings
					vm.Pier1,
					nameof( vm.Pier1.IsReady ) );
				{
					// property at level 2 ( key/value pair )
					catPier1.AddTextProperty(
						"Name",
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.Name ) );

					// container at level 3 ( collapsed )
					var catGeoPos = catPier1.AddCategory( "Geometric position", false );
					{
						// property at level 3 ( occupies full row )
						catGeoPos.AddTextFullRowProperty(
							false,
							// bindings
							vm.Pier1.GeoPos,
							nameof( vm.Pier1.GeoPos.Description ) );
					}

					// property at level 2 ( key/value pair with dimension )
					catPier1.AddTextDimProperty(
						"Offset",
						"[m]",
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.Offset ) );

					// dynamic list of properties at level 2
					foreach( var animal in vm.Pier1.Animals )
					{
						if( animal is ViewModelCat cat )
						{
							// property at level 2 ( key/value pair )
							catPier1.AddTextProperty(
								"Age",
								// bindings
								cat,
								nameof( cat.Age ) );
						}

						if( animal is ViewModelDog dog )
						{
							// property at level 2 ( key/value pair )
							catPier1.AddTextProperty(
								"Name",
								// bindings
								dog,
								nameof( dog.Name ) );
						}
					}

					// select radio button
					vm.Pier1.RadioOption = vm.Pier1.RadioOptions[1];

					// property at level 2 ( radio buttons )
					catPier1.AddRadioProperty(
						"grp",
						false,
						"Radio Option",
						vm.Pier1.RadioOptions,
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.RadioOption ) );

					// select in combo box
					vm.Pier1.ComboOption = vm.Pier1.ComboOptions[1];

					// property at level 2 ( combo box )
					catPier1.AddComboProperty(
						"Combo Option",
						vm.Pier1.ComboOptions,
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.ComboOption ) );

					// select in slider
					vm.Pier1.Darkness = 30;

					// property at level 2 ( slider )
					catPier1.AddSliderProperty(
						"Darkness",
						"%",
						1, 
						100,	
						1,
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.Darkness ) );
				}

				// container at level 2
				var catPier2 = catPiers.AddCategory( "Pier 2", true );
				{
					// property at level 2 ( key/value pair )
					catPier2.AddTextProperty(
						"Name",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.Name ) );

					// property at level 2 ( key/value pair )
					catPier2.AddTextProperty(
						"Description",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.Description ) );

					// property at level 2 ( key/checkbox pair )
					catPier2.AddCheckProperty(
						"Is ready",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.IsReady ) );

					// container at level 3 ( collapsed )
					var catGeoPos = catPier2.AddCategory( "Geometric position", true );
					{
						// property at level 3 ( key/value pair )
						catGeoPos.AddTextProperty(
							"Description",
							// bindings
							vm.Pier2.GeoPos,
							nameof( vm.Pier2.GeoPos.Description ) );

						// property at level 3 ( key/date )
						catGeoPos.AddDateProperty(
							"Date",
							// bindings
							vm.Pier2.GeoPos,
							nameof( vm.Pier2.GeoPos.Date ) );
					}
				}
			}
		}
	}
}
