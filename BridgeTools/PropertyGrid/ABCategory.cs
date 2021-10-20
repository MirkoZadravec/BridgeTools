using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BridgeTools.PropertyGrid
{
	public class ABCategory : ListView
	{
		public ABCategory AddCategory(
			string key,
			bool isExpanded )
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( "ABListViewStyle" ) as Style,
				ItemContainerStyle = this.FindResource( "ABListViewItemContainerStyle" ) as Style,
			};

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( "ABExpanderStyle" ) as Style,
					IsExpanded = isExpanded,
					Header = new TextBlock()
					{
						Text = key,
						Style = this.FindResource( "ABExpanderKeyStyle" ) as Style,
					},
					Content = child,
				},
			};

			this.Items.Add( propItem );

			return child;
		}

		public ABCategory AddCheckCategory(
			string key,
			bool isExpanded,
			object bSource,
			string bPath )
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( "ABListViewStyle" ) as Style,
				ItemContainerStyle = this.FindResource( "ABListViewItemContainerStyle" ) as Style,
			};

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABExpanderKeyValStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
				IsTabStop = true,
			};

			// binding (check box)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( CheckBox.IsCheckedProperty, b );

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( "ABExpanderStyle" ) as Style,
					IsExpanded = isExpanded,
					Header = dockPanel,
					Content = child,
				},
			};

			this.Items.Add( propItem );

			return child;
		}

		public ABProperty AddCheckProperty(
			string key,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
				IsTabStop = true,
			};

			// binding (check box)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( CheckBox.IsCheckedProperty, b );

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddRadioProperty<T>(
			string groupName,
			bool addBorder,
			string key,
			List<ComboItem<T>> values,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
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
				groupName = "grp" + "." + bPath;
			}

			var rc = new ABRadioConverter();

			foreach( var val in values )
			{
				var propRadio = new RadioButton()
				{
					GroupName = groupName,
					Content = val.ObjText,
					VerticalAlignment = VerticalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Bottom,
				};

				// binding (selected radio item)
				var b = new Binding( bPath ) { Source = bSource };
				b.Converter = rc;
				b.ConverterParameter = val;
				propRadio.SetBinding( RadioButton.IsCheckedProperty, b );

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

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddComboProperty<T>(
			string key,
			List<ComboItem<T>> values,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new StackPanel()
			{
				Orientation = Orientation.Vertical,
			};
			dockPanel.Children.Add( propVal );

			var propCombo = new ComboBox()
			{
				Style = this.FindResource( "ComboBoxStyle" ) as Style,
				VerticalAlignment = VerticalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Bottom,
				ItemsSource = values,
				DisplayMemberPath = nameof( ComboItem<T>.ObjText ),
				SelectedValuePath = nameof( ComboItem<T>.Obj ),
			};

			// binding (selected combo item)
			var b = new Binding( bPath ) { Source = bSource };
			propCombo.SetBinding( ComboBox.SelectedItemProperty, b );

			propVal.Children.Add( propCombo );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddSliderProperty(
			string key,
			string symbol,
			double sliderMin,
			double sliderMax,
			double sliderStep,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new StackPanel()
			{
				Orientation = Orientation.Vertical,
			};
			dockPanel.Children.Add( propVal );

			var dockPanelVal = new DockPanel()
			{
				LastChildFill = true,
			};
			propVal.Children.Add( dockPanelVal );

			var propSliderSymbol = new TextBlock()
			{
				Text = symbol,
			};
			DockPanel.SetDock( propSliderSymbol, Dock.Right );
			dockPanelVal.Children.Add( propSliderSymbol );

			var propSliderText = new TextBlock()
			{
			};
			dockPanelVal.Children.Add( propSliderText );

			// binding (selected slider value)
			var b = new Binding( bPath ) { Source = bSource };
			propSliderText.SetBinding( TextBlock.TextProperty, b );

			var propSlider = new Slider()
			{
				IsTabStop = false,
				Margin = new Thickness( 1 ),
				BorderThickness = new Thickness( 1 ),
				VerticalAlignment = VerticalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				AutoToolTipPlacement = System.Windows.Controls.Primitives.AutoToolTipPlacement.BottomRight,
				TickFrequency = sliderStep,
				IsSnapToTickEnabled = true,
				Minimum = sliderMin,
				Maximum = sliderMax,
				MinHeight = 16,
				Style = this.FindResource( "ABPropItemSliderStyle" ) as Style,
			};

			// binding (selected slider item)
			var bv = new Binding( bPath ) { Source = bSource };
			propSlider.SetBinding( Slider.ValueProperty, bv );

			propVal.Children.Add( propSlider );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddTextProperty(
			string key,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new TextBox()
			{
				Style = this.FindResource( "ABPropItemValStyle" ) as Style,
				IsTabStop = true,
			};

			// binding (text)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( TextBox.TextProperty, b );

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddDateProperty(
			string key,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new DatePicker()
			{
				Style = this.FindResource( "ABPropItemDateStyle" ) as Style,
				IsTabStop = true,
			};

			// binding (date)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( DatePicker.SelectedDateProperty, b );

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddTextDimProperty(
			string key,
			string symbol,
			object bSource,
			string bPath )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( "ABPropItemKeyStyle" ) as Style,
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

			var propVal = new TextBox()
			{
				Style = this.FindResource( "ABPropItemValStyle" ) as Style,
			};

			// binding (text)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( TextBox.TextProperty, b );

			dockPanelVal.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( "ABPropItemLevelStyle" ) as Style,
			};

			propItem.Content = dockPanel;

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddTextFullRowProperty(
			bool ignoreLevel,
			object bSource,
			string bPath )
		{
			var propVal = new TextBox()
			{
				Style = this.FindResource( "ABPropItemValStyle" ) as Style,
			};

			// binding (text)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( TextBox.TextProperty, b );

			var propItem = new ABProperty()
			{
				Style =
					ignoreLevel ?
					this.FindResource( "ABPropItemFullRowStyle" ) as Style :
					this.FindResource( "ABPropItemLevelStyle" ) as Style,
				Content = propVal,
			};

			this.Items.Add( propItem );

			return propItem;
		}
	}
}
