using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropTextFullRow : ABProp
	{
		private TextBox _textBox = null;

		public ABPropTextFullRow( 
			ABCat parent, 
			bool noLevelIndent ) : base()
		{
			InitStyle( parent, noLevelIndent );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropValTextBoxStyle ) as Style,
			};
			dockPanel.Children.Add( _textBox );

			parent.AddProperty( this, dockPanel );
		}

		/// <summary>
		/// Binding (text)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindText(
			object bSource,
			string bPath )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_textBox.SetBinding( TextBox.TextProperty, b );
		}
	}
}
