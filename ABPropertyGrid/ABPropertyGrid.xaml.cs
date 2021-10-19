using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

// TODO
//   - Tooltips

namespace AllplanBridge
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ABPropertyGrid : UserControl
    {
        public ABPropertyGrid()
        {
            InitializeComponent();
        }

		public void Clear()
		{
			Root.Items.Clear();
			Root.DataContext = null;
		}

		public ABCategory AddCategory(
			string key,
			bool isExpanded )
		{
			return AddCategory( null, key, isExpanded );
		}

		public ABCategory AddCategory(
			ABCategory parent,
			string key,
			bool isExpanded )
		{
			if( parent == null )
				parent = Root;

			var child = new ABCategory()
			{
				Style = Resources["ABListViewStyle"] as Style,
				ItemContainerStyle = Resources["ABListViewItemContainerStyle"] as Style,
			};

			var lvItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = Resources["ABExpanderStyle"] as Style,
					IsExpanded = isExpanded,
					Header = new TextBlock()
					{
						Text = key,
						Style = Resources["ABExpanderKeyStyle"] as Style,
					},
					Content = child,
				},
			};

			parent.Items.Add( lvItem );

			return child;
		}

		public ABCategory AddCheckCategory(
			ABCategory parent,
			string key,
			bool isExpanded,
			object bSource,
			string bPath )
		{
			if( parent == null )
				parent = Root;

			var child = new ABCategory()
			{
				Style = Resources["ABListViewStyle"] as Style,
				ItemContainerStyle = Resources["ABListViewItemContainerStyle"] as Style,
			};

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = Resources["ABExpanderKeyValStyle"] as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
			};

			// binding (check box)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( CheckBox.IsCheckedProperty, b );

			dockPanel.Children.Add( propVal );

			var lvItem = new ABProperty()
			{
				Content = new ABExpander()
				{
					Style = Resources["ABExpanderStyle"] as Style,
					IsExpanded = isExpanded,
					Header = dockPanel,
					Content = child,
				},
			};

			parent.Items.Add( lvItem );

			return child;
		}

		public ABProperty AddCheckProperty(
			ABCategory parent,
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
				Style = Resources["ABPropItemKeyStyle"] as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new CheckBox()
			{
				Content = "",
			};

			// binding (check box)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( CheckBox.IsCheckedProperty, b );

			dockPanel.Children.Add( propVal );

			var item = new ABProperty()
			{
				Style = Resources["ABPropItemLevelStyle"] as Style,
			};

			item.Content = dockPanel;

			parent.Items.Add( item );

			return item;
		}

		public ABProperty AddRadioProperty<T>(
			ABCategory parent,
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
				Style = Resources["ABPropItemKeyStyle"] as Style,
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

			var item = new ABProperty()
			{
				Style = Resources["ABPropItemLevelStyle"] as Style,
			};

			item.Content = dockPanel;

			parent.Items.Add( item );

			return item;
		}

		public ABProperty AddComboProperty<T>(
			ABCategory parent,
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
				Style = Resources["ABPropItemKeyStyle"] as Style,
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
				Style = Resources["ComboBoxStyle"] as Style,
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

			var item = new ABProperty()
			{
				Style = Resources["ABPropItemLevelStyle"] as Style,
			};

			item.Content = dockPanel;

			parent.Items.Add( item );

			return item;
		}

		public ABProperty AddSliderProperty(
			ABCategory parent,
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
				Style = Resources["ABPropItemKeyStyle"] as Style,
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
				IsTabStop = true,
				Margin = new Thickness( 1 ),
				BorderThickness = new Thickness( 1 ),
				VerticalAlignment = VerticalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				AutoToolTipPlacement = System.Windows.Controls.Primitives.AutoToolTipPlacement.BottomRight,
				TickFrequency = sliderStep,
				IsSnapToTickEnabled = true,
				Minimum = sliderMin,
				Maximum = sliderMax,
				Style = Application.Current.Resources["ABPropItemSliderStyle"] as Style,
			};

			// binding (selected slider item)
			var bv = new Binding( bPath ) { Source = bSource };
			propSlider.SetBinding( Slider.ValueProperty, bv );

			propVal.Children.Add( propSlider );

			var item = new ABProperty()
			{
				Style = Resources["ABPropItemLevelStyle"] as Style,
			};

			item.Content = dockPanel;

			parent.Items.Add( item );

			return item;
		}

		public ABProperty AddTextProperty(
			ABCategory parent,
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
				Style = Resources["ABPropItemKeyStyle"] as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var propVal = new TextBox()
			{
				Style = Resources["ABPropItemValStyle"] as Style,
			};

			// binding (text)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( TextBox.TextProperty, b );

			dockPanel.Children.Add( propVal );

			var item = new ABProperty()
			{
				Style = Resources["ABPropItemLevelStyle"] as Style,
			};

			item.Content = dockPanel;

			parent.Items.Add( item );

			return item;
		}

		public ABProperty AddTextFullRowProperty(
			ABCategory parent,
			bool ignoreLevel,
			object bSource,
			string bPath )
		{
			var propVal = new TextBox()
			{
				Style = Resources["ABPropItemValStyle"] as Style,
			};

			// binding (text)
			var b = new Binding( bPath ) { Source = bSource };
			propVal.SetBinding( TextBox.TextProperty, b );

			var item = new ABProperty()
			{
				Style =
					ignoreLevel ?
					Resources["ABPropItemFullRowStyle"] as Style :
					Resources["ABPropItemLevelStyle"] as Style,
				Content = propVal,
			};

			parent.Items.Add( item );

			return item;
		}
	}
}
