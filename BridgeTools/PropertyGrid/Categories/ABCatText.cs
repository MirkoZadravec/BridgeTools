//
// Copyright: (c) Allplan Infrastructure 2021
// ABCatText.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Categories
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Category with text label.
	/// </summary>
	/// <example>
	/// +------------+
	/// | Key label  |
	/// +------------+
	/// </example>
	public class ABCatText : ABCat
	{
		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Category key label</param>
		/// <param name="isExpanded">Initial expand/collapse state</param>
		/// <param name="toolTip">Category tooltip</param>
		/// <param name="toolTipProps">Child properties/categories tooltip</param>
		public ABCatText(
			ABCat parent,
			string key,
			bool isExpanded,
			string toolTip = null,
			string toolTipProps = null ) : base()
		{
			InitStyle( parent );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABCatKeyFullRowStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			parent.AddCategory( 
				this, 
				dockPanel, 
				isExpanded, 
				toolTip, 
				toolTipProps );
		}

		#endregion
	}
}
