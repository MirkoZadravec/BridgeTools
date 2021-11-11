using BridgeTools.PropertyGrid.Categories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABComboBoxProperty<T> : ABProperty
	{
		private ComboBox _comboBox = null;

		public ABComboBoxProperty(
			ABCategory parent,
			string key,
			List<ComboItem<T>> values ) : base()
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

			var propVal = new StackPanel()
			{
				Orientation = Orientation.Vertical,
			};
			dockPanel.Children.Add( propVal );

			_comboBox = new ComboBox()
			{
				Style = parent.FindResource( ABStyles.ABComboBoxStyle ) as Style,
				VerticalAlignment = VerticalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Bottom,
				ItemsSource = values,
				DisplayMemberPath = nameof( ComboItem<T>.ObjText ),
				SelectedValuePath = nameof( ComboItem<T>.Obj ),
			};

			propVal.Children.Add( _comboBox );

			var propItem = new ABProperty()
			{
				Style = parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

			parent.Items.Add( propItem );
		}

		/// <summary>
		/// Binding (selected combo item)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindSelectedItem(
			object bSource,
			string bPath )
		{
			if( null == _comboBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) { Source = bSource };
			_comboBox.SetBinding( ComboBox.SelectedItemProperty, b );
		}
	}
}
