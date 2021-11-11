using BridgeTools.PropertyGrid.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABTextFullRowProperty : ABProperty
	{
		private TextBox _textBox = null;

		public ABTextFullRowProperty( 
			ABCategory parent, 
			bool ignoreLevel ) : base()
		{
			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropItemValStyle ) as Style,
			};

			var propItem = new ABProperty()
			{
				Style =
					ignoreLevel ?
					parent.FindResource( ABStyles.ABPropItemFullRowStyle ) as Style :
					parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = _textBox,
			};

			parent.Items.Add( propItem );
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
