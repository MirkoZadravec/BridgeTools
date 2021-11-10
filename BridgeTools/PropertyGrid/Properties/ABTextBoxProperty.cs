﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABTextBoxProperty : ABProperty
	{
		private TextBox _textBox = null;

		public ABTextBoxProperty(
			ABCategory parent,
			string key ) : base()
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

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropItemValStyle ) as Style,
				IsTabStop = true,
			};

			dockPanel.Children.Add( _textBox );

			var propItem = new ABProperty()
			{
				Style = parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style,
				Content = dockPanel,
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