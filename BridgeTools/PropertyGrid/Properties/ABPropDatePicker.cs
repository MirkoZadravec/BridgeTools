using BridgeTools.PropertyGrid.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropDatePicker : ABProp
	{
		private DatePicker _datePicker = null;

		public ABPropDatePicker(
			ABCat parent,
			string key )
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

			_datePicker = new DatePicker()
			{
				Style = parent.FindResource( ABStyles.ABPropItemDateStyle ) as Style,
				IsTabStop = true,
			};
			dockPanel.Children.Add( _datePicker );

			this.Content = dockPanel;

			parent.Items.Add( this );
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

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_datePicker.SetBinding( DatePicker.SelectedDateProperty, b );
		}
	}
}
