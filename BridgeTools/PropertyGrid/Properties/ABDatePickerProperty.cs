using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABDatePickerProperty : ABProperty
	{
		private DatePicker _datePicker = null;

		public ABDatePickerProperty(
			ABCategory parent,
			string key )
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

			_datePicker = new DatePicker()
			{
				Style = parent.FindResource( ABStyles.ABPropItemDateStyle ) as Style,
				IsTabStop = true,
			};

			dockPanel.Children.Add( _datePicker );

			var propItem = new ABProperty()
			{
				Style = parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

			parent.Items.Add( propItem );
		}

		/// <summary>
		/// Binding (date)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
		public void BindDate(
			object bSource,
			string bPath )
		{
			if( null == _datePicker )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) { Source = bSource };
			_datePicker.SetBinding( DatePicker.SelectedDateProperty, b );
		}
	}
}
