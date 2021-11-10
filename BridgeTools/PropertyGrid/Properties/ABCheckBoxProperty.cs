using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABCheckBoxProperty : ABProperty
	{
		private CheckBox _checkBox = null;

		public ABCheckBoxProperty( 
			ABCategory parent,
			string key,
			bool isThreeState ) : base()
		{
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

			_checkBox = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};

			dockPanel.Children.Add( _checkBox );

			this.Style = parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style;
			this.Content = dockPanel;

			parent.Items.Add( this );
		}

		/// <summary>
		/// Binding (check box - IsChecked)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
		public void BindIsChecked( 
			object bSource,
			string bPathChecked)
		{
			if( null == _checkBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPathChecked ) )
				return;

			var b = new Binding( bPathChecked ) { Source = bSource };
			_checkBox.SetBinding( CheckBox.IsCheckedProperty, b );
		}

		/// <summary>
		/// Binding (IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathEnabled"></param>
		public void BindIsEnabled(
			object bSource,
			string bPathEnabled )
		{
			if( null == bSource || string.IsNullOrEmpty( bPathEnabled ) )
				return;

			var b = new Binding( bPathEnabled ) { Source = bSource };
			this.SetBinding( ABProperty.IsEnabledProperty, b );
		}
	}
}
