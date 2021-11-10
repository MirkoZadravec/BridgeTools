using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace BridgeTools.PropertyGrid
{
	public class ABCategory : ListView
	{
		public ABCategory AddCategory(
			string key,
			bool isExpanded,
			object bSource,
			string bPathEnabled,
			string bPathEnabledChildren )
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( ABStyles.ABListViewStyle ) as Style,
				ItemContainerStyle = this.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style,
			};

			// binding (children - IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabledChildren ) )
			{
				var bEnabled = new Binding( bPathEnabledChildren ) { Source = bSource };
				child.SetBinding( ABCategory.IsEnabledProperty, bEnabled );
			}

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = new TextBlock()
					{
						Text = key,
						Style = this.FindResource( ABStyles.ABExpanderKeyStyle ) as Style,
					},
					Content = child,
				},
			};

			// binding (IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabled ) )
			{
				var bEnabled = new Binding( bPathEnabled ) { Source = bSource };
				propItem.SetBinding( ABProperty.IsEnabledProperty, bEnabled );
			}

			this.Items.Add( propItem );

			return child;
		}

		public ABCategory AddCheckCategory(
			string key,
			bool isExpanded,
			bool isThreeState,
			object bSource,
			string bPathChecked,
			string bPathEnabled,
			string bPathEnabledChildren)
		{
			var child = new ABCategory()
			{
				Style = this.FindResource( ABStyles.ABListViewStyle ) as Style,
				ItemContainerStyle = this.FindResource( ABStyles.ABListViewItemContainerStyle ) as Style,
			};

			// binding (children - IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabledChildren ) )
			{
				var bEnabled = new Binding( bPathEnabledChildren ) { Source = bSource };
				child.SetBinding( ABCategory.IsEnabledProperty, bEnabled );
			}

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( ABStyles.ABExpanderKeyValStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};

			// binding (check box - IsChecked)
			if( null != bSource && !string.IsNullOrEmpty( bPathChecked ) )
			{
				var b = new Binding( bPathChecked ) { Source = bSource };
				propVal.SetBinding( CheckBox.IsCheckedProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = dockPanel,
					Content = child,
				},
			};

			// binding (IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabled ) )
			{
				var bEnabled = new Binding( bPathEnabled ) { Source = bSource };
				propItem.SetBinding( ABProperty.IsEnabledProperty, bEnabled );
			}

			this.Items.Add( propItem );

			return child;
		}

		public ABProperty AddCheckProperty(
			string key,
			bool isThreeState,
			object bSource,
			string bPathChecked,
			string bPathEnabled )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};

			// binding (check box - IsChecked)
			if( null != bSource && !string.IsNullOrEmpty( bPathChecked ) )
			{
				var b = new Binding( bPathChecked ) { Source = bSource };
				propVal.SetBinding( CheckBox.IsCheckedProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

			// binding (IsEnabled)
			if( null != bSource && !string.IsNullOrEmpty( bPathEnabled ) )
			{
				var b = new Binding( bPathEnabled ) { Source = bSource };
				propItem.SetBinding( ABProperty.IsEnabledProperty, b );
			}

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
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
				if( null != bSource && !string.IsNullOrEmpty( bPath ) )
				{
					var b = new Binding( bPath ) { Source = bSource };
					b.Converter = rc;
					b.ConverterParameter = val;
					propRadio.SetBinding( RadioButton.IsCheckedProperty, b );
				}

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
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
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
				Style = this.FindResource( ABStyles.ABComboBoxStyle ) as Style,
				VerticalAlignment = VerticalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Bottom,
				ItemsSource = values,
				DisplayMemberPath = nameof( ComboItem<T>.ObjText ),
				SelectedValuePath = nameof( ComboItem<T>.Obj ),
			};

			// binding (selected combo item)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propCombo.SetBinding( ComboBox.SelectedItemProperty, b );
			}

			propVal.Children.Add( propCombo );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
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
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propSliderText.SetBinding( TextBlock.TextProperty, b );
			}

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
				Style = this.FindResource( ABStyles.ABPropItemSliderStyle ) as Style,
			};

			// binding (selected slider item)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var bv = new Binding( bPath ) { Source = bSource };
				propSlider.SetBinding( Slider.ValueProperty, bv );
			}

			propVal.Children.Add( propSlider );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new TextBox()
			{
				Style = this.FindResource( ABStyles.ABPropItemValStyle ) as Style,
				IsTabStop = true,
			};

			// binding (text)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propVal.SetBinding( TextBox.TextProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new DatePicker()
			{
				Style = this.FindResource( ABStyles.ABPropItemDateStyle ) as Style,
				IsTabStop = true,
			};

			// binding (date)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propVal.SetBinding( DatePicker.SelectedDateProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddColorProperty(
			string key,
			Color automaticColor,
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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new ColorPickerPalette()
			{
				MinHeight = 18,
				AutomaticColor = new SolidColorBrush( automaticColor ),
				IsTabStop = true,
			};

			// binding (color)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propVal.SetBinding( ColorPickerPalette.ColorProperty, b );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

			this.Items.Add( propItem );

			return propItem;
		}

		public ABProperty AddButtonProperty(
			string key,
			CommandBinding bCommand )
		{
			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new Button()
			{
				Content = key,
				IsEnabled = true,
				MinHeight = 20.0,
				Margin = new Thickness( 1.0, 2.0, 1.0, 2.0 ),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				Style = this.FindResource( ABStyles.ABButtonStyle ) as Style,
			};

			// binding (click)
			if( bCommand != null )
			{
				propVal.Command = bCommand.Command;
				propVal.CommandBindings.Add( bCommand );
			}

			dockPanel.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemKeyStyle ) as Style,
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
				Style = this.FindResource( ABStyles.ABPropItemValStyle ) as Style,
			};

			// binding (text)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propVal.SetBinding( TextBox.TextProperty, b );
			}

			dockPanelVal.Children.Add( propVal );

			var propItem = new ABProperty()
			{
				Style = this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
			};

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
				Style = this.FindResource( ABStyles.ABPropItemValStyle ) as Style,
			};

			// binding (text)
			if( null != bSource && !string.IsNullOrEmpty( bPath ) )
			{
				var b = new Binding( bPath ) { Source = bSource };
				propVal.SetBinding( TextBox.TextProperty, b );
			}

			var propItem = new ABProperty()
			{
				Style =
					ignoreLevel ?
					this.FindResource( ABStyles.ABPropItemFullRowStyle ) as Style :
					this.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = propVal,
			};

			this.Items.Add( propItem );

			return propItem;
		}
	}
}
