//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropRadioBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using abmControls.PropertyGrid.Categories;
using abmControls.PropertyGrid.Converters;
using abmControls.PropertyGrid.Resources;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace abmControls.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with radio buttons.
	/// </summary>
	/// <example>
	/// +------------+---------------------------------------------------------------------------------+
	/// |            | (x) GroupItem[0].ObjText (with GroupItem[0].Obj & tooltip GroupItem[0].ObjInfo) |
	/// | Key label  | (x) GroupItem[1].ObjText (with GroupItem[1].Obj & tooltip GroupItem[1].ObjInfo) |
	/// |            | (x) etc.                                                                        |
	/// |            |                   --------- Border line (optional) --------                     |
	/// +------------+---------------------------------------------------------------------------------+
	/// </example>
	public class ABPropRadioBox<T> : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Radio buttons.
		/// </summary>
		private List<RadioButton> _radioButtons = new List<RadioButton>();

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="groupName">Radio button group name (must be unique). Gets unique Guid if null is given.</param>
		/// <param name="bottomBorder">Border on bottom, used if another radio group follows</param>
		/// <param name="key">Property key label</param>
		/// <param name="values">Radio button items</param>
		public ABPropRadioBox(
			ABCat parent,
			string groupName,
			bool bottomBorder,
			string key,
			List<GroupItem<T>> values ) : base()
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

			if( string.IsNullOrEmpty( groupName ) )
			{
				// try to set unique group name
				groupName = Guid.NewGuid().ToString();
			}

			foreach( var val in values )
			{
				var propRadio = new RadioButton()
				{
					GroupName = groupName,
					Content = val.ObjText,
					ToolTip = val.ObjInfo,
					VerticalAlignment = VerticalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Bottom,
					// remember for binding
					Tag = val,
				};
				propVal.Children.Add( propRadio );

				// remember for binding
				_radioButtons.Add( propRadio );
			}

			if( bottomBorder )
			{
				var border = new Border()
				{
					BorderThickness = new Thickness( 0, 0, 0, 1 ),
					BorderBrush = new SolidColorBrush( Colors.LightGray ),
				};
				propVal.Children.Add( border );
			}

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Selected radio item binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindSelectedItem(
			object bSource,
			string bPath )
		{
			if( null == _radioButtons || _radioButtons.Count == 0 )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var rc = new ABConvRadio();

			foreach( var radioButton in _radioButtons )
			{
				var b = new Binding( bPath ) 
				{ 
					Source = bSource 
				};

				b.Converter = rc;
				b.ConverterParameter = radioButton.Tag; // take stored item

				radioButton.SetBinding( RadioButton.IsCheckedProperty, b );
			}
		}

		#endregion
	}
}
