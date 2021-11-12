using BridgeTools.PropertyGrid.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropButton : ABProp
	{
		private Button _button = null;

		public ABPropButton( 
			ABCat parent, 
			string key ) : base()
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

			_button = new Button()
			{
				Content = key,
				IsEnabled = true,
				MinHeight = 20.0,
				Margin = new Thickness( 1.0, 2.0, 1.0, 2.0 ),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				Style = parent.FindResource( ABStyles.ABButtonStyle ) as Style,
			};
			dockPanel.Children.Add( _button );

			parent.AddProperty( this, dockPanel );
		}

		/// <summary>
		/// Binding (button command)
		/// </summary>
		/// <param name="bCommand"></param>
		public void BindCommand( CommandBinding bCommand )
		{
			if( null == _button )
				return;

			if( null == bCommand )
				return;

			_button.Command = bCommand.Command;
			_button.CommandBindings.Add( bCommand );
		}
	}
}
