using BridgeTools.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace BridgeToolsTest
{
	/// <summary>
	/// View model.
	/// </summary>
	public class ViewModelPiers
	{
		public string Project { get; set; }
		public ViewModelPier Pier1 { get; set; } = new ViewModelPier() { Name = "Pier 1", Description = "Long pier", Offset = "7.5" };
		public ViewModelPier Pier2 { get; set; } = new ViewModelPier() { Name = "Pier 2", Description = "Short pier", Offset = "5.3" };
	}

	public enum RadioOptionsEnum
	{
		One,
		Two,
		Three
	}

	public enum ComboOptionsEnum
	{
		First,
		Second,
		Third
	}

	public class ViewModelPier
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsReady { get; set; }
		public string Offset { get; set; }
		public double Darkness { get; set; }
		public ViewModelGeoPos GeoPos { get; set; } = new ViewModelGeoPos() { Description = "This is a geometric position", Date = DateTime.Now, Color = Colors.Red };
		public List<ViewModelAnimal> Animals = new List<ViewModelAnimal>() { new ViewModelCat() { Age = "5" }, new ViewModelDog() { Name = "Ben" } };

		public List<ComboItem<RadioOptionsEnum>> RadioOptions = new List<ComboItem<RadioOptionsEnum>>()
		{
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.One, "One" ),
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.Two, "Two" ),
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.Three, "Three" )
		};
		public ComboItem<RadioOptionsEnum> RadioOption { get; set; } = null;

		public List<ComboItem<ComboOptionsEnum>> ComboOptions = new List<ComboItem<ComboOptionsEnum>>()
		{
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.First, "First" ),
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.Second, "Second" ),
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.Third, "Third" )
		};
		public ComboItem<ComboOptionsEnum> ComboOption { get; set; } = null;
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Custom commands (global).
	/// </summary>
	public static class CCustomCommands
	{
	}

	public class ViewModelGeoPos
	{
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public Color Color { get; set; }

		#region Commands

		public static readonly RoutedUICommand ButtonCmd = new RoutedUICommand
		(
			"My command",
			nameof( ButtonCmd ),
			typeof( CCustomCommands )
		);

		public void ButtonCmd_CanExecute( object sender, CanExecuteRoutedEventArgs e )
		{
			e.CanExecute = true;
		}

		public void ButtonCmd_Executed( object sender, ExecutedRoutedEventArgs e )
		{
			e.Handled = true;

			System.Windows.MessageBox.Show( "OK" );
		}

		#endregion
	}

	public class ViewModelAnimal
	{
	}

	public class ViewModelDog : ViewModelAnimal
	{
		public string Name { get; set; }
	}

	public class ViewModelCat : ViewModelAnimal
	{
		public string Age { get; set; }
	}
}
