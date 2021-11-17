//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropDatePicker.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with date picker.
	/// </summary>
	/// <example>
	/// +------------+---------------------------------------------------------+
	/// | Key label  | Date text    Date picker button (invisible if disabled) |
	/// +------------+---------------------------------------------------------+
	/// </example>
	public class ABPropDatePicker : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Date picker control.
		/// </summary>
		private DatePicker _datePicker = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		public ABPropDatePicker(
			ABCat parent,
			string key )
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

			_datePicker = new DatePicker()
			{
				Style = parent.FindResource( ABStyles.ABPropValDateStyle ) as Style,
				IsTabStop = true,
			};
			dockPanel.Children.Add( _datePicker );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Selected date binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindDate(
			object bSource,
			string bPath )
		{
			if( null == _datePicker )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_datePicker.SetBinding( DatePicker.SelectedDateProperty, b );
		}

		#endregion
	}
}
