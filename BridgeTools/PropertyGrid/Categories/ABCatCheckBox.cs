using BridgeTools.PropertyGrid.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Categories
{
	public class ABCatCheckBox : ABCat
	{
		private ABProp _property = null;
		private CheckBox _checkBox = null;

		public ABCatCheckBox( 
			ABCat parent, 
			string key,
			bool isExpanded,
			bool isThreeState ) : base()
		{
			this.Style = parent.FindResource( ABStyles.ABListViewStyle ) as Style;
			this.ItemContainerStyle = parent.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style;

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABExpanderKeyValStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			_checkBox = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};
			dockPanel.Children.Add( _checkBox );

			_property = new ABProp()
			{
				Content = new ABExpander()
				{
					Style = parent.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = dockPanel,
					Content = this,
				},
			};
			parent.Items.Add( _property );
		}

		/// <summary>
		/// Binding (IsChecked)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindIsChecked(
			object bSource,
			string bPath )
		{
			if( null == _checkBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_checkBox.SetBinding( CheckBox.IsCheckedProperty, b );
		}

		/// <summary>
		/// Binding (IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindIsEnabled(
			object bSource,
			string bPath )
		{
			if( null == _property )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_property.SetBinding( ABProp.IsEnabledProperty, b );
		}

		/// <summary>
		/// Binding (children - IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
		public void BindIsChildEnabled(
			object bSource,
			string bPath )
		{
			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			this.SetBinding( ABCat.IsEnabledProperty, b );
		}
	}
}
