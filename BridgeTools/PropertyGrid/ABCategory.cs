using BridgeTools.PropertyGrid.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid
{
	public class ABCategory : ListView
	{
		public ABCategory AddCategory(
			string key,
			bool isExpanded,
			object bSource,
			string bPathEnabled,
			string bPathEnabledChildren )
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( ABStyles.ABListViewStyle ) as Style,
				ItemContainerStyle = this.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style,
			};

			// binding (children - IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabledChildren ) )
			{
				var bEnabled = new Binding( bPathEnabledChildren ) { Source = bSource };
				child.SetBinding( ABCategory.IsEnabledProperty, bEnabled );
			}

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = new TextBlock()
					{
						Text = key,
						Style = this.FindResource( ABStyles.ABExpanderKeyStyle ) as Style,
					},
					Content = child,
				},
			};

			// binding (IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabled ) )
			{
				var bEnabled = new Binding( bPathEnabled ) { Source = bSource };
				propItem.SetBinding( ABProperty.IsEnabledProperty, bEnabled );
			}

			this.Items.Add( propItem );

			return child;
		}

		public ABCategory AddCheckCategory(
			string key,
			bool isExpanded,
			bool isThreeState,
			object bSource,
			string bPathChecked,
			string bPathEnabled,
			string bPathEnabledChildren)
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( ABStyles.ABListViewStyle ) as Style,
				ItemContainerStyle = this.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style,
			};

			// binding (children - IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabledChildren ) )
			{
				var bEnabled = new Binding( bPathEnabledChildren ) { Source = bSource };
				child.SetBinding( ABCategory.IsEnabledProperty, bEnabled );
			}

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( ABStyles.ABExpanderKeyValStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};

			// binding (check box - IsChecked)
			if( null != bSource && !string.IsNullOrEmpty( bPathChecked ) )
			{
				var b = new Binding( bPathChecked ) { Source = bSource };
				propVal.SetBinding( CheckBox.IsCheckedProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = dockPanel,
					Content = child,
				},
			};

			// binding (IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabled ) )
			{
				var bEnabled = new Binding( bPathEnabled ) { Source = bSource };
				propItem.SetBinding( ABProperty.IsEnabledProperty, bEnabled );
			}

			this.Items.Add( propItem );

			return child;
		}
	}
}
