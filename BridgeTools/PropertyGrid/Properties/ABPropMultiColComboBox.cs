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
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with multi-column combo box. Showing of columns header is optional.
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

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Show columns header in multi-column combo box.
		/// </summary>
		private bool _showComboColHeader = true;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="values">Combo box items (per column)</param>
		/// <param name="columns">Column headers (if all names are null, no header is shown).
		/// The size of this list determines total number of columns.</param>
		public ABPropMultiColComboBox(
			ABCat parent,
			string key,
			List<GroupItemMulti<T>> values,
			List<string> columns ) : base()
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

			// detect number of columns
			var ncol = columns != null ? columns.Count : 0;
			foreach( var val in values )
			{
				// reduce number of columns if no value exists (avoid binding exception)
				var nvalCol = val.ObjTexts != null ? val.ObjTexts.Count : 0;
				ncol = Math.Min( nvalCol, ncol );
			}

			_comboBox = new SfMultiColumnDropDownControl()
			{
				DisplayMember = ncol > 0 ? nameof( GroupItemMulti<T>.ObjTexts ) + "[0]" : null,
				SelectedValue = nameof( GroupItem<T>.Obj ),
				Style = parent.FindResource( ABStyles.ABPropValMultiComboStyle ) as Style,
				ItemsSource = values,
			};
			_comboBox.Loaded += OnComboBoxLoaded;

			// detect if column header is empty
			_showComboColHeader = false;

			// create columns
			for( int icol = 0 ; icol<ncol ; icol++ )
			{
				var headerText = columns[icol];

				if( !string.IsNullOrEmpty( headerText ) )
				{
					// hide columns header
					_showComboColHeader = true;
				}

				_comboBox.Columns.Add( new GridTextColumn()
				{
					MappingName = nameof( GroupItemMulti<T>.ObjTexts ) + "[" + icol + "]",
					HeaderStyle = parent.FindResource( ABStyles.ABPropValMultiComboHeaderStyle ) as Style,
					HorizontalHeaderContentAlignment = HorizontalAlignment.Left,
					HeaderText = headerText,
					TextAlignment = TextAlignment.Left,
					ColumnSizer = ( icol == ncol -1 ) ? GridLengthUnitType.AutoLastColumnFill : GridLengthUnitType.Star,
					MinimumWidth = 100,
				} );
			}
			propVal.Children.Add( _comboBox );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Events

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Combo box loaded event.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnComboBoxLoaded( object sender, RoutedEventArgs e )
		{
			// need for initial loading only
			_comboBox.Loaded -= OnComboBoxLoaded;

			if( !_showComboColHeader )
			{
				// hide columns header
				_comboBox.GetDropDownGrid().HeaderRowHeight = 0;
			}
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
