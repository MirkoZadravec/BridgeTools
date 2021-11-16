//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropTextBoxDim.cs
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
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with text box and dimension label.
	/// </summary>
	/// <example>
	/// +------------+-----------------------------------------+
	/// | Key label  | Editable text box     | Dimension label |
	/// +------------+-----------------------------------------+
	/// </example>
	public class ABPropTextBoxDim : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text edit field.
		/// </summary>
		private TextBox _textBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="symbol">Dimension symbol label</param>
		public ABPropTextBoxDim(
			ABCat parent,
			string key,
			string symbol ) : base()
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

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropValTextBoxStyle ) as Style,
			};
			dockPanelVal.Children.Add( _textBox );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text box binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
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

		#endregion
	}
}
