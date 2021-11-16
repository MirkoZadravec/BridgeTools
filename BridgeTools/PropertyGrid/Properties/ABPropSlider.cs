using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropSlider : ABProp
	{
		private Slider _slider = null;
		private TextBlock _sliderTextBox = null;

		public ABPropSlider(
			ABCat parent,
			string key,
			string symbol,
			double sliderMin,
			double sliderMax,
			double sliderStep ) : base()
		{
			InitStyle( parent, false );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABPropKeyStyle ) as Style,
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

			_sliderTextBox = new TextBlock()
			{
			};
			dockPanelVal.Children.Add( _sliderTextBox );

			_slider = new Slider()
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
				Style = parent.FindResource( ABStyles.ABPropValSliderStyle ) as Style,
			};
			propVal.Children.Add( _slider );

			parent.AddProperty( this, dockPanel );
		}

		/// <summary>
		/// Binding (selected slider item and text)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindValue(
			object bSource,
			string bPath )
		{
			if( null == _slider || null == _sliderTextBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_slider.SetBinding( Slider.ValueProperty, b );
			_sliderTextBox.SetBinding( TextBlock.TextProperty, b );
		}
	}
}
