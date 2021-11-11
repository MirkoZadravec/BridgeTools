using BridgeTools.PropertyGrid.Categories;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropColorPickerPalette : ABProp
	{
		private ColorPickerPalette _colorPickerPalette = null;

		public ABPropColorPickerPalette(
			ABCat parent,
			string key,
			Color automaticColor ) : base()
		{
			this.Style = parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style;

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
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

			this.Content = dockPanel;

			parent.Items.Add( this );
		}

		/// <summary>
		/// Binding (color)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
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
	}
}
