using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Categories
{
	public class ABCatCheckBox : ABCat
	{
		private CheckBox _checkBox = null;

		public ABCatCheckBox( 
			ABCat parent, 
			string key,
			bool isExpanded,
			bool isThreeState ) : base()
		{
			InitStyle( parent );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABCatKeyValStyle ) as Style,
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

			parent.AddCategory( this, dockPanel, isExpanded );
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
	}
}
