using System.Windows;

namespace ABPropertyGridTest
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
			pg.Clear();
		}

		private void OnPropGridOpen( object sender, RoutedEventArgs e )
		{
			var vm = new ViewModelPiers() { Project = "Project 1" };

			// container at level 1
			var catPiers = pg.AddCategory( "Piers", true );
			{
				// property at level 1 ( key/value pair )
				pg.AddTextProperty(
					catPiers,
					"Project",
					// bindings
					vm,
					nameof( vm.Project ) );

				// container at level 2 (with checkbox)
				var catPier1 = pg.AddCheckCategory(
					catPiers,
					"Pier 1",
					true,
					// bindings
					vm.Pier1,
					nameof( vm.Pier1.IsReady ) );
				{
					// property at level 2 ( key/value pair )
					pg.AddTextProperty(
						catPier1,
						"Name",
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.Name ) );

					// container at level 3 ( collapsed )
					var catGeoPos = pg.AddCategory( catPier1, "Geometric position", false );
					{
						// property at level 3 ( occupies full row )
						pg.AddTextFullRowProperty(
							catGeoPos,
							false,
							// bindings
							vm.Pier1.GeoPos,
							nameof( vm.Pier1.GeoPos.Description ) );
					}

					// property at level 2 ( key/value pair )
					pg.AddTextProperty(
						catPier1,
						"Description",
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.Description ) );

					// list of properties at level 2
					foreach( var animal in vm.Pier1.Animals )
					{
						if( animal is ViewModelCat cat )
						{
							// property at level 2 ( key/value pair )
							pg.AddTextProperty(
								catPier1,
								"Age",
								// bindings
								cat,
								nameof( cat.Age ) );
						}

						if( animal is ViewModelDog dog )
						{
							// property at level 2 ( key/value pair )
							pg.AddTextProperty(
								catPier1,
								"Name",
								// bindings
								dog,
								nameof( dog.Name ) );
						}
					}

					// select radio button
					vm.Pier1.RadioOption = vm.Pier1.RadioOptions[1];

					// property at level 2 ( radio buttons )
					pg.AddRadioProperty(
						catPier1,
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
					pg.AddComboProperty(
						catPier1,
						"Combo Option",
						vm.Pier1.ComboOptions,
						// bindings
						vm.Pier1,
						nameof( vm.Pier1.ComboOption ) );

					// select in slider
					vm.Pier1.Darkness = 30;

					// property at level 2 ( slider )
					pg.AddSliderProperty(
						catPier1,
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
				var catPier2 = pg.AddCategory( catPiers, "Pier 2", true );
				{
					// property at level 2 ( key/value pair )
					pg.AddTextProperty(
						catPier2,
						"Name",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.Name ) );

					// property at level 2 ( key/value pair )
					pg.AddTextProperty(
						catPier2,
						"Description",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.Description ) );

					// property at level 2 ( key/checkbox pair )
					pg.AddCheckProperty(
						catPier2,
						"Is ready",
						// bindings
						vm.Pier2,
						nameof( vm.Pier2.IsReady ) );

					// container at level 3 ( collapsed )
					var catGeoPos = pg.AddCategory( catPier2, "Geometric position", false );
					{
						// property at level 3 ( key/value pair )
						pg.AddTextProperty(
							catGeoPos,
							"Description",
							// bindings
							vm.Pier2.GeoPos,
							nameof( vm.Pier2.GeoPos.Description ) );
					}
				}
			}
		}
	}
}
