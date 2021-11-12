using BridgeTools.PropertyGrid.Properties;
using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Categories
{
	public class ABCat : ListView
	{
		protected void InitStyle( ABCat parent )
		{
			this.Style = parent.FindResource( ABStyles.ABListViewStyle ) as Style;
			this.ItemContainerStyle = parent.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style;
		}

		internal void AddProperty( ABProp prop )
		{
			this.Items.Add( prop );
		}
	}
}
