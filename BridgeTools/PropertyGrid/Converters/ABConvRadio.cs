//
// Copyright: (c) Allplan Infrastructure 2021
// ABConvRadio.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System;
using System.Windows;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Converters
{
	//------------------------------------------------------------------------------------------
	/// <summary>
	/// Radio buttons converter.
	/// </summary>
	internal class ABConvRadio : IValueConverter
	{
		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source</param>
		/// <param name="targetType">The type of the binding target property</param>
		/// <param name="parameter">The converter parameter to use</param>
		/// <param name="culture">The culture to use in the converter</param>
		/// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			// ALBG-2917: Crash - Pier creation radio buttons
			// https://stackoverflow.com/questions/17082551/getting-the-index-of-the-selected-radiobutton-in-a-group

			if( value == null || parameter == null )
				return false;
			else
				return value == parameter;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target</param>
		/// <param name="targetType">The type to convert to</param>
		/// <param name="parameter">The converter parameter to use</param>
		/// <param name="culture">The culture to use in the converter</param>
		/// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			// ALBG-2917: Crash - Pier creation radio buttons
			// https://stackoverflow.com/questions/17082551/getting-the-index-of-the-selected-radiobutton-in-a-group
			if( value == null || parameter == null )
				return null;
			else if( (bool) value )
				return parameter;
			else
				return DependencyProperty.UnsetValue;
		}
	}
}
