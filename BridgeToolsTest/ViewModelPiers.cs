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
using System.Windows;
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
	public class ViewModelPier : ViewModelBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsReady { get; set; }
		public bool IsEnabledReady { get; set; }
		public bool IsVisibleReady { get; set; } = true;
		public bool IsDone { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsVisible { get; set; } = true;
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
		private GroupItem<RadioOptionsEnum> _radioOption = null;
		public GroupItem<RadioOptionsEnum> RadioOption
		{
			get { return _radioOption; }
			set { _radioOption = value; }
		}

		public void InitRadioOption( GroupItem<RadioOptionsEnum> radioOption )
		{
			_radioOption = radioOption;
		}

		public List<GroupItem<ComboOptionsEnum>> ComboOptions = new List<GroupItem<ComboOptionsEnum>>()
		{
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.First, "First" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Second, "Second" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Third, "Third" )
		};
		private GroupItem<ComboOptionsEnum> _comboOption = null;
		public GroupItem<ComboOptionsEnum> ComboOption 
		{
			get { return _comboOption; } 
			set 
			{
				_comboOption = value;

				// hide entire category
				if( _comboOption.Obj == ComboOptionsEnum.First )
				{
					IsVisible = false;
					OnPropertyChanged( nameof( IsVisible ) );
				}

				// hide particular property
				if( _comboOption.Obj == ComboOptionsEnum.Second )
				{
					IsVisibleReady = false;
					OnPropertyChanged( nameof( IsVisibleReady ) );
				}

				// special case for known "varies" situation
				if( _comboOption.Obj == ComboOptionsEnum.Third )
				{
					ComboOptions.RemoveAt( 0 );

					if( RefreshComboOptions != null )
						RefreshComboOptions();
				}
			} 
		}

		public void InitComboOption( GroupItem<ComboOptionsEnum> comboOption )
		{
			_comboOption = comboOption;
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
		public bool IsEnabledDate { get; set; } = true;
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
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.First, "First" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Second, "Second" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Third, "Third" )
		};
		private GroupItem<ComboOptionsEnum> _comboOption = null;
		public GroupItem<ComboOptionsEnum> ComboOption
		{
			get { return _comboOption; }
			set { _comboOption = value; }
		}

		public void InitComboOption( GroupItem<ComboOptionsEnum> comboOption )
		{
			_comboOption = comboOption;
		}
	}
}
