using BridgeTools.PropertyGrid.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropTextDim : ABProp
	{
		private TextBox _textBox = null;

		public ABPropTextDim(
			ABCat parent,
			string key,
			string symbol ) : base()
		{
			InitStyle( parent, false );

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

			var dockPanelVal = new DockPanel()
			{
				LastChildFill = true,
			};
			dockPanel.Children.Add( dockPanelVal );

			var propSymbol = new TextBlock()
			{
				Text = symbol,
			};
			DockPanel.SetDock( propSymbol, Dock.Right );
			dockPanelVal.Children.Add( propSymbol );

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropItemValStyle ) as Style,
			};
			dockPanelVal.Children.Add( _textBox );

			this.Content = dockPanel;

			parent.AddProperty( this );
		}

		/// <summary>
		/// Binding (text)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
		public void BindText(
			object bSource,
			string bPath )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_textBox.SetBinding( TextBox.TextProperty, b );
		}
	}
}
