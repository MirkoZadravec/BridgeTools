using BridgeTools.PropertyGrid.Categories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropRadioBox<T> : ABProp
	{
		private List<RadioButton> _radioButtons = new List<RadioButton>();

		public ABPropRadioBox(
			ABCat parent,
			string groupName,
			bool addBorder,
			string key,
			List<ComboItem<T>> values ) : base()
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

			var propVal = new StackPanel()
			{
				Orientation = Orientation.Vertical,
			};
			dockPanel.Children.Add( propVal );

			if( string.IsNullOrEmpty( groupName ) )
			{
				// try to set unique group name
				groupName = Guid.NewGuid().ToString();
			}

			foreach( var val in values )
			{
				var propRadio = new RadioButton()
				{
					GroupName = groupName,
					Content = val.ObjText,
					VerticalAlignment = VerticalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Bottom,
					// store the item
					Tag = val,
				};

				_radioButtons.Add( propRadio );

				propVal.Children.Add( propRadio );
			}

			if( addBorder )
			{
				var border = new Border()
				{
					BorderThickness = new Thickness( 0, 0, 0, 1 ),
					BorderBrush = new SolidColorBrush( Colors.LightGray ),
				};
				propVal.Children.Add( border );
			}

			this.Content = dockPanel;

			parent.Items.Add( this );
		}

		/// <summary>
		/// Binding (selected radio item)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindSelectedItem(
			object bSource,
			string bPath )
		{
			if( null == _radioButtons || _radioButtons.Count == 0 )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var rc = new ABRadioConverter();

			foreach( var radioButton in _radioButtons )
			{
				var b = new Binding( bPath ) 
				{ 
					Source = bSource 
				};

				b.Converter = rc;
				b.ConverterParameter = radioButton.Tag; // take stored item

				radioButton.SetBinding( RadioButton.IsCheckedProperty, b );
			}
		}
	}
}
