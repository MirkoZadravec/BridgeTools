//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropTextBoxFullRow.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using abmControls.PropertyGrid.Categories;
using abmControls.PropertyGrid.Controls;
using abmControls.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace abmControls.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with text box filing the entire row. 
	/// Indent by depth level can be optionally ignored.
	/// </summary>
	/// <example>
	/// +-----------------------+
	/// | Editable text box     |
	/// +-----------------------+
	/// </example>
	public class ABPropTextBoxFullRow : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text edit field.
		/// </summary>
		private ABTextBox _textBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Contructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="noLevelIndent">True if no indent by depth level</param>
		public ABPropTextBoxFullRow( 
			ABCat parent, 
			bool noLevelIndent ) : base()
		{
			InitStyle( parent, noLevelIndent );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			_textBox = new ABTextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropValTextBoxStyle ) as Style,
			};
			dockPanel.Children.Add( _textBox );

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
