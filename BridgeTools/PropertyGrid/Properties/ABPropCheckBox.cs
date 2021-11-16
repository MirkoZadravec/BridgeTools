﻿using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABPropCheckBox : ABProp
	{
		private CheckBox _checkBox = null;

		public ABPropCheckBox( 
			ABCat parent,
			string key,
			bool isThreeState ) : base()
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

			_checkBox = new CheckBox()
			{
				Content = "",
				IsThreeState = isThreeState,
				IsTabStop = true,
			};
			dockPanel.Children.Add( _checkBox );

			parent.AddProperty( this, dockPanel );
		}

		/// <summary>
		/// Binding (check box - IsChecked)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
		public void BindIsChecked( 
			object bSource,
			string bPath)
		{
			if( null == _checkBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource 
			};

			_checkBox.SetBinding( CheckBox.IsCheckedProperty, b );
		}

		/// <summary>
		/// Binding (IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathEnabled"></param>
		public void BindIsEnabled(
			object bSource,
			string bPathEnabled )
		{
			if( null == bSource || string.IsNullOrEmpty( bPathEnabled ) )
				return;

			var b = new Binding( bPathEnabled ) 
			{ 
				Source = bSource 
			};

			this.SetBinding( ABProp.IsEnabledProperty, b );
		}
	}
}
