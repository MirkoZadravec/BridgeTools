//
// Copyright: (c) Allplan Infrastructure 2021
// ABCat.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Controls;
using BridgeTools.PropertyGrid.Properties;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Categories
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Base category item class (control).
	/// </summary>
	public class ABCat : ListView
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Property control representing a row with its children.
		/// </summary>
		private ABProp _property = null;

		#endregion

		#region Styling

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Set initial style.
		/// </summary>
		/// <param name="parent">Parent category</param>
		protected void InitStyle( ABCat parent )
		{
			this.Style = parent.FindResource( ABStyles.ABCatStyle ) as Style;
			this.ItemContainerStyle = parent.FindResource( ABStyles.ABCatItemsStyle ) as Style;
		}

		#endregion

		#region Insertion

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Add child property.
		/// </summary>
		/// <param name="prop">Child property</param>
		/// <param name="header">Child property content</param>
		internal void AddProperty( 
			ABProp prop, 
			FrameworkElement header )
		{
			prop.Content = header;

			this.Items.Add( prop );
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Add child category.
		/// </summary>
		/// <param name="category">Child category</param>
		/// <param name="header">Child category content</param>
		/// <param name="isExpanded">Initial expand state</param>
		/// <param name="toolTip">Category tooltip</param>
		/// <param name="toolTipProps">Child properties/categories tooltip</param>
		internal void AddCategory( 
			ABCat category, 
			FrameworkElement header, 
			bool isExpanded,
			string toolTip,
			string toolTipProps )
		{
			// category tooltip
			header.ToolTip = toolTip;
			// children tooltips
			category.ToolTip = toolTipProps;

			category._property = new ABProp()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = header,
					Content = category,
				},
			};

			this.Items.Add( category._property );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// IsEnabled binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindIsEnabled(
			object bSource,
			string bPath )
		{
			if( null == _property )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource
			};

			_property.SetBinding( ABProp.IsEnabledProperty, b );
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// IsEnabled binding for the children only 
		/// (the category is still manually expandable).
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindArePropsEnabled(
			object bSource,
			string bPath )
		{
			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource
			};

			this.SetBinding( ABCat.IsEnabledProperty, b );
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// IsVisible binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindIsVisible(
			object bSource,
			string bPath )
		{
			if( null == _property )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource
			};

			_property.SetBinding( ABProp.VisibilityProperty, b );
		}

		#endregion
	}
}
