//
// Copyright: (c) Allplan Infrastructure 2021
// ABCatCheckBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Categories
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Category with checkbox (can be three state).
	/// </summary>
	/// <example>
	/// +------------+-----+
	/// | Key label  | (x) |
	/// +------------+-----+
	/// </example>
	public class ABCatCheckBox : ABCat
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Check box control.
		/// </summary>
		private CheckBox _checkBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="isThreeState">Three state check box</param>
		/// <param name="isExpanded">Initial expand state</param>
		/// <param name="toolTip">Category tooltip</param>
		/// <param name="toolTipProps">Child properties/categories tooltip</param>
		public ABCatCheckBox( 
			ABCat parent, 
			string key,
			bool isThreeState,
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
				Style = parent.FindResource( ABStyles.ABCatKeyValStyle ) as Style,
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

			parent.AddCategory( 
				this, 
				dockPanel, 
				isExpanded, 
				toolTip, 
				toolTipProps );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// IsChecked binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindIsChecked(
			object bSource,
			string bPath )
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

		#endregion
	}
}
