using BridgeTools.PropertyGrid.Categories;
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
			bool ignoreLevel ) : base()
		{
			this.Style =
				ignoreLevel ?
				parent.FindResource( ABStyles.ABPropItemFullRowStyle ) as Style :
				parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style;

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropItemValStyle ) as Style,
			};

			this.Content = _textBox;

			parent.Items.Add( this );
		}

		/// <summary>
		/// Binding (text)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
		public void BindText(
			object bSource,
			string bPath )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) { Source = bSource };
			_textBox.SetBinding( TextBox.TextProperty, b );
		}
	}
}
