//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropColorPickerPalette.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with color picker.
	/// </summary>
	/// <example>
	/// +------------+---------------------+
	/// | Key label  | Color picker button |
	/// +------------+---------------------+
	/// </example>
	public class ABPropColorPickerPalette : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Color picker control.
		/// </summary>
		private ColorPickerPalette _colorPickerPalette = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="automaticColor">Default color</param>
		public ABPropColorPickerPalette(
			ABCat parent,
			string key,
			Color automaticColor ) : base()
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

			_colorPickerPalette = new ColorPickerPalette()
			{
				MinHeight = 18,
				AutomaticColor = new SolidColorBrush( automaticColor ),
				IsTabStop = true,
			};
			dockPanel.Children.Add( _colorPickerPalette );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Selected color binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindColor(
			object bSource,
			string bPath )
		{
			if( null == _colorPickerPalette )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_colorPickerPalette.SetBinding( ColorPickerPalette.ColorProperty, b );
		}

		#endregion
	}
}
