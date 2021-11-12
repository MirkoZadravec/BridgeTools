using BridgeTools.PropertyGrid.Categories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropComboBox<T> : ABProp
	{
		private ComboBox _comboBox = null;

		public ABPropComboBox(
			ABCat parent,
			string key,
			List<ComboItem<T>> values ) : base()
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

			parent.AddProperty( this, dockPanel );
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

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_comboBox.SetBinding( ComboBox.SelectedItemProperty, b );
		}
	}
}
