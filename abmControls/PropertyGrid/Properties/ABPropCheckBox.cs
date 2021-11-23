//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropCheckBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using abmControls.PropertyGrid.Categories;
using abmControls.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace abmControls.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with checkbox (can be three state).
	/// </summary>
	/// <example>
	/// +------------+-----+
	/// | Key label  | (x) |
	/// +------------+-----+
	/// </example>
	public class ABPropCheckBox : ABProp
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

		#endregion
	}
}
