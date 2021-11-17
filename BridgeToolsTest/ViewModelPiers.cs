//
// Copyright: (c) Allplan Infrastructure 2021
// ViewModelPiers.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace BridgeToolsTest
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelPiers
	{
		public string Project { get; set; }
		public ViewModelPier Pier1 { get; set; } = new ViewModelPier() 
		{ 
			Name = "Pier 1", 
			Description = "Long pier", 
			Offset = "7.5",
			IsDone = false,
			IsReady = false,
			IsEnabledReady = false,
			IsEnabled = true,
		};
		public ViewModelPier Pier2 { get; set; } = new ViewModelPier() 
		{ 
			Name = "Pier 2", 
			Description = "Short pier", 
			Offset = "5.3",
			IsDone = true,
			IsReady = null,
			IsEnabledReady = false,
			IsEnabled = true,
		};
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Enum for testing.
	/// </summary>
	public enum RadioOptionsEnum
	{
		One,
		Two,
		Three
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Enum for testing.
	/// </summary>
	public enum ComboOptionsEnum
	{
		First,
		Second,
		Third
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Callback to refresh combo box items.
	/// </summary>
	public delegate void CallbackComboBoxRefresh();

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelPier
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsReady { get; set; }
		public bool IsEnabledReady { get; set; }
		public bool IsDone { get; set; }
		public bool IsEnabled { get; set; }
		public string Offset { get; set; }
		public double Darkness { get; set; }
		public ViewModelGeoPos GeoPos { get; set; } = new ViewModelGeoPos() { Description = "This is a geometric position", Date = DateTime.Now, Color = Colors.Red };
		public List<ViewModelAnimal> Animals = new List<ViewModelAnimal>() 
		{
			new ViewModelLion() {},
			new ViewModelCat() { Age = "5" }, 
			new ViewModelDog() { Name = "Ben" } };

		public List<GroupItem<RadioOptionsEnum>> RadioOptions = new List<GroupItem<RadioOptionsEnum>>()
		{
			new GroupItem<RadioOptionsEnum>(RadioOptionsEnum.One, "One", "Tooltip 1" ),
			new GroupItem<RadioOptionsEnum>(RadioOptionsEnum.Two, "Two", "Tooltip 2" ),
			new GroupItem<RadioOptionsEnum>(RadioOptionsEnum.Three, "Three", "Tooltip 3" )
		};
		public GroupItem<RadioOptionsEnum> RadioOption { get; set; } = null;

		public List<GroupItem<ComboOptionsEnum>> ComboOptions = new List<GroupItem<ComboOptionsEnum>>()
		{
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.First, "First", null ),
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.Second, "Second", null ),
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.Third, "Third", null )
		};
		private GroupItem<ComboOptionsEnum> _comboOption = null;
		public GroupItem<ComboOptionsEnum> ComboOption 
		{
			get 
			{
				return _comboOption;
			} 
			set 
			{
				_comboOption = value;

				// special case for known "varies" situation
				if( _comboOption.Obj == ComboOptionsEnum.Third )
				{
					ComboOptions.RemoveAt( 0 );

					if( RefreshComboOptions != null )
						RefreshComboOptions();
				}
			} 
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Callback to refresh combo box items.
		/// </summary>
		public CallbackComboBoxRefresh RefreshComboOptions { private get; set; } = null;
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Custom commands (global).
	/// </summary>
	public static class CCustomCommands
	{
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
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

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelAnimal
	{
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelDog : ViewModelAnimal
	{
		public string Name { get; set; }
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelCat : ViewModelAnimal
	{
		public string Age { get; set; }
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelLion : ViewModelAnimal
	{
		public List<GroupItem<ComboOptionsEnum>> ComboOptions = new List<GroupItem<ComboOptionsEnum>>()
		{
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.First, "First", null ),
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.Second, "Second", null ),
			new GroupItem<ComboOptionsEnum>(ComboOptionsEnum.Third, "Third", null )
		};
		public GroupItem<ComboOptionsEnum> ComboOption { get; set; } = null;
	}
}
