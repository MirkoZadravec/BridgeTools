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
				SelectedValue = nameof( GroupItem<T>.Obj ),
				Style = parent.FindResource( ABStyles.ABDropDownStyle ) as Style,
				Template = parent.FindResource( ABStyles.ABDropDownControlTemplate ) as ControlTemplate,
				ItemsSource = values,
			};

			_comboBox.Columns.Add( new GridTextColumn()
			{
				MappingName = nameof( GroupItemMulti<T>.ObjTexts ) + "[0]",
				HeaderStyle = parent.FindResource( ABStyles.ABDropDownGridHeaderStyle ) as Style,
				HorizontalHeaderContentAlignment = HorizontalAlignment.Left,
				HeaderText = "Column1",
				TextAlignment = TextAlignment.Left,
				ColumnSizer = GridLengthUnitType.Star,
				MinimumWidth = 100,
			} );

			_comboBox.Columns.Add( new GridTextColumn()
			{
				MappingName = nameof( GroupItemMulti<T>.ObjTexts ) + "[1]",
				HeaderStyle = parent.FindResource( ABStyles.ABDropDownGridHeaderStyle ) as Style,
				HorizontalHeaderContentAlignment = HorizontalAlignment.Left,
				HeaderText = "Column2",
				TextAlignment = TextAlignment.Left,
				ColumnSizer = GridLengthUnitType.AutoLastColumnFill,
				MinimumWidth = 100,
			} );
			propVal.Children.Add( _comboBox );

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

			_comboBox.SetBinding( SfMultiColumnDropDownControl.SelectedItemProperty, b );
		}

		#endregion
	}
}
