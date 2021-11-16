using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Categories
{
	public class ABCatText : ABCat
	{
		public ABCatText(
			ABCat parent,
			string key,
			bool isExpanded ) : base()
		{
			InitStyle( parent );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABCatKeyFullRowStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			parent.AddCategory( this, dockPanel, isExpanded );
		}
	}
}
