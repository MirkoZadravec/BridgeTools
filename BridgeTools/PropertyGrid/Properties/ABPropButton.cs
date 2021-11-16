//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropButton.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with button.
	/// </summary>
	/// <example>
	/// +------------+--------+
	/// | Key label  | Button |
	/// +------------+--------+
	/// </example>
	public class ABPropButton : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Button control.
		/// </summary>
		private Button _button = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="val">Button label</param>
		public ABPropButton( 
			ABCat parent, 
			string key,
			string val) : base()
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

			_button = new Button()
			{
				Content = val,
				IsEnabled = true,
				MinHeight = 20.0,
				Margin = new Thickness( 1.0, 2.0, 1.0, 2.0 ),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				Style = parent.FindResource( ABStyles.ABPropValButtonStyle ) as Style,
			};
			dockPanel.Children.Add( _button );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Command binding.
		/// </summary>
		/// <param name="bCommand">Command</param>
		public void BindCommand( CommandBinding bCommand )
		{
			if( null == _button )
				return;

			if( null == bCommand )
				return;

			_button.Command = bCommand.Command;
			_button.CommandBindings.Add( bCommand );
		}

		#endregion
	}
}
