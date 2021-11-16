﻿using BridgeTools.PropertyGrid.Controls;
using BridgeTools.PropertyGrid.Properties;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Categories
{
	public class ABCat : ListView
	{
		private ABProp _property = null;

		protected void InitStyle( ABCat parent )
		{
			this.Style = parent.FindResource( ABStyles.ABCatStyle ) as Style;
			this.ItemContainerStyle = parent.FindResource( ABStyles.ABCatItemsStyle ) as Style;
		}

		internal void AddProperty( ABProp prop, object header )
		{
			prop.Content = header;

			this.Items.Add( prop );
		}

		internal void AddCategory( ABCat category, object header, bool isExpanded )
		{
			_property = new ABProp()
			{
				Content = new ABExpander()
				{
					Style = this.FindResource( ABStyles.ABExpanderStyle ) as Style,
					IsExpanded = isExpanded,
					Header = header,
					Content = category,
				},
			};

			this.Items.Add( _property );
		}

		/// <summary>
		/// Binding (IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPath"></param>
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

		/// <summary>
		/// Binding (children - IsEnabled)
		/// </summary>
		/// <param name="bSource"></param>
		/// <param name="bPathChecked"></param>
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
	}
}