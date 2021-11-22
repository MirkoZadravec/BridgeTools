//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropMultiColComboBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with multi-column combo box.
	/// </summary>
	/// <example>
	/// +------------+--------------------------------------------------------+------------------------|
	/// | Key label  | GroupItem[1..n].ObjTexts[0] (with GroupItem[1..n].Obj) | ...ObjTexts[1]... etc. |
	/// +------------+--------------------------------------------------------+------------------------+
	/// </example>
	public class ABPropMultiColComboBox<T> : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Multi-column combo box.
		/// </summary>
		/// <remarks>Using Syncfusion.Data.WPF.dll and Syncfusion.SfGrid.WPF.dll</remarks>
		private SfMultiColumnDropDownControl _comboBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="values">Combo box items (per column)</param>
		public ABPropMultiColComboBox(
			ABCat parent,
			string key,
			List<GroupItemMulti<T>> values ) : base()
		{
			InitStyle( parent, false );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABPropKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new StackPanel()
			{
				Orientation = Orientation.Vertical,
			};
			dockPanel.Children.Add( propVal );

			_comboBox = new SfMultiColumnDropDownControl()
			{
				DisplayMember = nameof( GroupItemMulti<T>.ObjTexts ) + "[0]",
				//Margin = new Thickness( 1.0, 0.0, 1.0, 0.0 ),
				//Height = 20,
				//Background = new SolidColorBrush( Color.FromRgb( 255, 255, 255 ) ), //255, 199, 207, 215 ) ),
				//BorderThickness = new Thickness( 0 ),
				//BorderBrush = new SolidColorBrush( Color.FromRgb( 173, 216, 230 ) ),
				//PopupBorderThickness = new Thickness( 1 ),
				//PopupDropDownGridBackground = new SolidColorBrush( Color.FromRgb( 255, 255, 255 ) ),
				//TextAlignment = TextAlignment.Left,
				//PopupBorderBrush = new SolidColorBrush( Color.FromRgb( 173, 216, 230 ) ),
				//FontFamily = new FontFamily( "Segoe UI" ),
				//FontSize = 12.0,
				//PopupBackground = new SolidColorBrush( Color.FromArgb( 255, 24, 115, 174 ) ),
				//AutoGenerateColumns = false,
				//GridColumnSizer = GridLengthUnitType.Star,
				//Style = Application.Current.Resources["abmDropDownStyle2"] as Style,
				//Template = Application.Current.Resources["abmDropDownControlTemplate2"] as ControlTemplate,
				//IsEnabled = true,
			};

			_comboBox.Columns.Add( new GridTextColumn()
			{
				MappingName = nameof( GroupItemMulti<T>.ObjTexts ) + "[0]",
				//HeaderStyle = Application.Current.Resources["abmDropDownGridHeaderStyle"] as Style,
				HeaderText = "Column1",
				TextAlignment = TextAlignment.Left,
				HorizontalHeaderContentAlignment = HorizontalAlignment.Left,
				ColumnSizer = GridLengthUnitType.Star,
				Width = 108,
			} );

			_comboBox.Columns.Add( new GridTextColumn()
			{
				MappingName = nameof( GroupItemMulti<T>.ObjTexts ) + "[1]",
				//HeaderStyle = Application.Current.Resources["abmDropDownGridHeaderStyle"] as Style,
				HeaderText = "Column2",
				TextAlignment = TextAlignment.Left,
				HorizontalHeaderContentAlignment = HorizontalAlignment.Left,
				ColumnSizer = GridLengthUnitType.AutoLastColumnFill,
				Width = 108,
			} );
			propVal.Children.Add( _comboBox );

			/*			_comboBox = new ComboBox()
						{
							Style = parent.FindResource( ABStyles.ABPropValComboBoxStyle ) as Style,
							VerticalAlignment = VerticalAlignment.Center,
							VerticalContentAlignment = VerticalAlignment.Bottom,
							ItemsSource = values,
							DisplayMemberPath = nameof( GroupItem<T>.ObjText ),
							SelectedValuePath = nameof( GroupItem<T>.Obj ),
						};
						propVal.Children.Add( _comboBox );*/

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Selected combo box item binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindSelectedItem(
			object bSource,
			string bPath )
		{
			if( null == _comboBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource
			};

			_comboBox.SetBinding( ComboBox.SelectedItemProperty, b );
		}

		#endregion
	}
}
