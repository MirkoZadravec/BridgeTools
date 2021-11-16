using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Properties;
using System.Windows.Input;
using System.Windows.Media;

namespace BridgeToolsTest
{
	public class Test
	{
		public static void Open( ABCat pgRoot )
		{
			var vm = new ViewModelPiers() { Project = "Project 1" };

			// container at level 1
			var catPiers = new ABCatText( pgRoot, "Piers", true );
			{
				// property at level 1 ( key/value pair )
				var propProjName = new ABPropTextBox( catPiers, "Project" );
				// bindings
				propProjName.BindText( vm, nameof( vm.Project ) );

				// container at level 2 (with checkbox)
				var catPier1 = new ABCatCheckBox( catPiers, "Pier 1", true, false );
				catPier1.BindIsChecked( vm.Pier1, nameof( vm.Pier1.IsDone ) );
				catPier1.BindIsEnabled( vm.Pier1, nameof( vm.Pier1.IsEnabled ) );
				catPier1.BindArePropsEnabled( vm.Pier1, nameof( vm.Pier1.IsEnabled ) );
				{
					// property at level 2 ( key/value pair )
					var propPierName = new ABPropTextBox( catPier1, "Name" );
					// bindings
					propPierName.BindText( vm.Pier1, nameof( vm.Pier1.Name ) );

					// container at level 3 ( collapsed )
					var catGeoPos = new ABCatText( catPier1, "Geometric position", false );
					{
						// property at level 3 ( occupies full row )
						var tf = new ABPropTextBoxFullRow( catGeoPos, false );
						// bindings
						tf.BindText( vm.Pier1.GeoPos, nameof( vm.Pier1.GeoPos.Description ) );
					}

					// property at level 2 ( key/value pair with dimension )
					var td = new ABPropTextBoxDim( catPier1, "Offset", "[m]" );
					// bindings
					td.BindText( vm.Pier1, nameof( vm.Pier1.Offset ) );

					// dynamic list of properties at level 2
					foreach( var animal in vm.Pier1.Animals )
					{
						if( animal is ViewModelCat cat )
						{
							// property at level 2 ( key/value pair )
							var propCatAge = new ABPropTextBox( catPier1, "Cat age" );
							// bindings
							propCatAge.BindText( cat, nameof( cat.Age ) );
						}

						if( animal is ViewModelDog dog )
						{
							// property at level 2 ( key/value pair )
							var propDogName = new ABPropTextBox( catPier1, "Dog name" );
							// bindings
							propDogName.BindText( dog, nameof( dog.Name ) );
						}

						if( animal is ViewModelLion lion )
						{
							// select in combo box
							lion.ComboOption = lion.ComboOptions[1];

							// property at level 2 ( combo box )
							var cbLion = new ABPropComboBox<ComboOptionsEnum>( catPier1, "Lion options", lion.ComboOptions );
							// bindings
							cbLion.BindSelectedItem( lion, nameof( lion.ComboOption ) );
						}
					}

					// select radio button
					vm.Pier1.RadioOption = vm.Pier1.RadioOptions[1];

					// property at level 2 ( radio buttons )
					var rb = new ABPropRadioBox<RadioOptionsEnum>(
						catPier1,
						"grp",
						false,
						"Radio Option",
						vm.Pier1.RadioOptions );
					// bindings
					rb.BindSelectedItem( vm.Pier1, nameof( vm.Pier1.RadioOption ) );

					// select in combo box
					vm.Pier1.ComboOption = vm.Pier1.ComboOptions[1];

					// property at level 2 ( combo box )
					var cbP = new ABPropComboBox<ComboOptionsEnum>( catPier1, "Combo Option", vm.Pier1.ComboOptions );
					// bindings
					cbP.BindSelectedItem( vm.Pier1, nameof( vm.Pier1.ComboOption ) );

					// select in slider
					vm.Pier1.Darkness = 30;

					// property at level 2 ( slider )
					var s = new ABPropSlider( catPier1, "Darkness", "%", 1, 100, 1 );
					// bindings
					s.BindValue( vm.Pier1, nameof( vm.Pier1.Darkness ) );
				}

				// container at level 2
				var catPier2 = new ABCatText( catPiers, "Pier 2", true );
				catPier2.BindIsEnabled( vm.Pier2, nameof( vm.Pier2.IsEnabled ) );
				catPier2.BindArePropsEnabled( vm.Pier2, nameof( vm.Pier2.IsEnabled ) );
				{
					// property at level 2 ( key/value pair )
					var propPierName = new ABPropTextBox( catPier2, "Name" );
					// bindings
					propPierName.BindText( vm.Pier2, nameof( vm.Pier2.Name ) );

					// property at level 2 ( key/value pair )
					var propPierDescr = new ABPropTextBox( catPier2, "Description" );
					// bindings
					propPierDescr.BindText( vm.Pier2, nameof( vm.Pier2.Description ) );

					// property at level 2 ( key/checkbox pair - three state )
					var c1 = new ABPropCheckBox( catPier2, "Is ready", true );
					// bindings
					c1.BindIsChecked( vm.Pier2, nameof( vm.Pier2.IsReady ) );
					c1.BindIsEnabled( vm.Pier2, nameof( vm.Pier2.IsEnabledReady ) );

					// property at level 2 ( key/checkbox pair - two state )
					var c2 = new ABPropCheckBox( catPier2, "Is done", false );
					// bindings
					c2.BindIsChecked( vm.Pier2, nameof( vm.Pier2.IsDone ) );

					// container at level 3 ( collapsed )
					var catGeoPos = new ABCatText( catPier2, "Geometric position", true );
					{
						// property at level 3 ( key/value pair )
						var propGeoPosDescr = new ABPropTextBox( catGeoPos, "Description" );
						// bindings
						propGeoPosDescr.BindText( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Description ) );

						// property at level 3 ( key/date )
						var d = new ABPropDatePicker( catGeoPos, "Date" );
						// bindings
						d.BindDate( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Date ) );

						// property at level 3 ( key/color )
						var c = new ABPropColorPickerPalette( catGeoPos, "Color", Colors.Black );
						// bindings
						c.BindColor( vm.Pier2.GeoPos, nameof( vm.Pier2.GeoPos.Color ) );

						// property at level 3 ( key/button )
						var b = new ABPropButton( catGeoPos, "Parameters", "Press" );
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
