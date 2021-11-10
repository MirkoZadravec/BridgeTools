using BridgeTools.PropertyGrid.Properties;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
			var catPiers = propGrid.AddCategory( 
				"Piers", 
				true,
				// bindings
				null, 
				null, 
				null );
			{
				// property at level 1 ( key/value pair )
				var propProjName = new ABTextBoxProperty( catPiers, "Project" );
				{
					// bindings
					propProjName.BindText( vm, nameof( vm.Project ) );
				}

				// container at level 2 (with checkbox)
				var catPier1 = catPiers.AddCheckCategory(
					"Pier 1",
					true,
					false,
					// bindings
					vm.Pier1,
					nameof( vm.Pier1.IsDone ),
					nameof( vm.Pier1.IsEnabled ),
					nameof( vm.Pier1.IsEnabled ) );
				{
					// property at level 2 ( key/value pair )
					var propPierName = new ABTextBoxProperty( catPier1, "Name" );
					{
						// bindings
						propPierName.BindText( vm.Pier1, nameof( vm.Pier1.Name ) );
					}

					// container at level 3 ( collapsed )
					var catGeoPos = catPier1.AddCategory( "Geometric position", false, null, null, null );
					{
						// property at level 3 ( occupies full row )
						var tf = new ABTextFullRowProperty( catGeoPos, false );
						{
							// bindings
							tf.BindText( vm.Pier1.GeoPos, nameof( vm.Pier1.GeoPos.Description ) );
						}
					}

					// property at level 2 ( key/value pair with dimension )
					var td = new ABTextDimProperty( catPier1, "Offset", "[m]" );
					{
						// bindings
						td.BindText( vm.Pier1, nameof( vm.Pier1.Offset ) );
					}

					// dynamic list of properties at level 2
					foreach( var animal in vm.Pier1.Animals )
					{
						if( animal is ViewModelCat cat )
						{
							// property at level 2 ( key/value pair )
							var propCatAge = new ABTextBoxProperty( catPier1, "Cat age" );
							{
								// bindings
								propCatAge.BindText( cat, nameof( cat.Age ) );
							}
						}

						if( animal is ViewModelDog dog )
						{
							// property at level 2 ( key/value pair )
							var propDogName = new ABTextBoxProperty( catPier1, "Dog name" );
							{
								// bindings
								propDogName.BindText( dog, nameof( dog.Name ) );
							}
						}

						if( animal is ViewModelLion lion )
						{
							// select in combo box
							lion.ComboOption = lion.ComboOptions[1];

							// property at level 2 ( combo box )
							var cbLion = new ABComboBoxProperty<ComboOptionsEnum>( catPier1, "Lion options", lion.ComboOptions );
							{
								// bindings
								cbLion.BindSelectedItem( lion, nameof( lion.ComboOption ) );
							}
						}
					}

					// select radio button
					vm.Pier1.RadioOption = vm.Pier1.RadioOptions[1];

					// property at level 2 ( radio buttons )
					var rb = new ABRadioBoxProperty<RadioOptionsEnum>(
						catPier1,
						"grp",
						false,
						"Radio Option",
						vm.Pier1.RadioOptions );
					{
						// bindings
						rb.BindSelectedItem( vm.Pier1, nameof( vm.Pier1.RadioOption ) );
					}

					// select in combo box
					vm.Pier1.ComboOption = vm.Pier1.ComboOptions[1];

					// property at level 2 ( combo box )
					var cbP = new ABComboBoxProperty<ComboOptionsEnum>( catPier1, "Combo Option", vm.Pier1.ComboOptions );
					{
						// bindings
						cbP.BindSelectedItem( vm.Pier1, nameof( vm.Pier1.ComboOption ) );
					}

					// select in slider
					vm.Pier1.Darkness = 30;

					// property at level 2 ( slider )
					var s = new ABSliderProperty( catPier1, "Darkness", "%", 1, 100, 1 );
					{
						// bindings
						s.BindValue( vm.Pier1, nameof( vm.Pier1.Darkness ) );
					}
				}

				// container at level 2
				var catPier2 = catPiers.AddCategory( 
					"Pier 2", 
					true,
					// bindings
					vm.Pier2,
					nameof( vm.Pier2.IsEnabled ),
					nameof( vm.Pier2.IsEnabled ) );
				{
					// property at level 2 ( key/value pair )
					var propPierName = new ABTextBoxProperty( catPier2, "Name" );
					{
						// bindings
						propPierName.BindText( vm.Pier2, nameof( vm.Pier2.Name ) );
					}

					// property at level 2 ( key/value pair )
					var propPierDescr = new ABTextBoxProperty( catPier2, "Description" );
					{
						// bindings
						propPierDescr.BindText( vm.Pier2, nameof( vm.Pier2.Description ) );
					}

					// property at level 2 ( key/checkbox pair - three state )
					var c1 = new ABCheckBoxProperty( catPier2, "Is ready", true );
					{
						// bindings
						c1.BindIsChecked( vm.Pier2, nameof( vm.Pier2.IsReady ) );
						c1.BindIsEnabled( vm.Pier2, nameof( vm.Pier2.IsEnabledReady ) );
					}

					// property at level 2 ( key/checkbox pair - two state )
					var c2 = new ABCheckBoxProperty( catPier2, "Is done", false );
					{
						// bindings
						c2.BindIsChecked( vm.Pier2, nameof( vm.Pier2.IsDone ) );
					}

					// container at level 3 ( collapsed )
					var catGeoPos = catPier2.AddCategory( 
						"Geometric position", 
						true,
						// bindings
						null, 
						null, 
						null );
					{
						// property at level 3 ( key/value pair )
						var propGeoPosDescr = new ABTextBoxProperty( catGeoPos, "Description" );
						{
							// bindings
							propGeoPosDescr.BindText( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Description ) );
						}

						// property at level 3 ( key/date )
						var d = new ABDatePickerProperty( catGeoPos, "Date" );
						{
							// bindings
							d.BindDate( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Date ) );
						}

						// property at level 3 ( key/color )
						var c = new ABColorProperty( catGeoPos, "Color", Colors.Black );
						{
							// bindings
							c.BindColor( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Color ) );
						}

						// property at level 3 ( key/button )
						var b = new ABButtonProperty( catGeoPos, "Parameters" );
						{
							// bindings
							b.BindCommand( 
								new CommandBinding(
									ViewModelGeoPos.ButtonCmd,
									vm.Pier2.GeoPos.ButtonCmd_Executed,
									vm.Pier2.GeoPos.ButtonCmd_CanExecute ) );
						}
					}
				}
			}
		}
	}
}
