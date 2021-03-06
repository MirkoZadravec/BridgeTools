//
// Copyright: (c) Allplan Infrastructure 2021
// ABConvLevelToOffset.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System;
using System.Windows.Data;

namespace abmControls.PropertyGrid.Converters
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Converter.
	/// </summary>
	internal class ABConvLevelToOffset : IValueConverter
	{
		//----------------------------------------------------------------------------------------------
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
			// thumb + spacing = Position of category text
			double spaceLevel = 10 + 5;

			if( value is int valLevel )
				return valLevel * spaceLevel;

			return 0;
		}

		//----------------------------------------------------------------------------------------------
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
			return 0;
		}
	}
}
