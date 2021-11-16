//
// Copyright: (c) Allplan Infrastructure 2021
// ABConvLevelToSplitterOffset.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Converters
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Converter.
	/// </summary>
	internal class ABConvLevelToSplitterOffset : IMultiValueConverter
	{
		#region IMultiValueConverter Members

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts source values to a value for the binding target. The data binding engine
		/// calls this method when it propagates the values from source bindings to the binding
		/// target.
		/// </summary>
		/// <param name="values">The array of values that the source bindings in the System.Windows.Data.MultiBinding
		/// produces. The value System.Windows.DependencyProperty.UnsetValue indicates that
		/// the source binding has no value to provide for conversion.</param>
		/// <param name="targetType">The type of the binding target property</param>
		/// <param name="parameter">The converter parameter to use</param>
		/// <param name="culture">The culture to use in the converter</param>
		/// <returns>A converted value.If the method returns null, the valid null value is used.A
		/// return value of System.Windows.DependencyProperty.System.Windows.DependencyProperty.UnsetValue
		/// indicates that the converter did not produce a value, and that the binding will
		/// use the System.Windows.Data.BindingBase.FallbackValue if it is available, or
		/// else will use the default value.A return value of System.Windows.Data.Binding.System.Windows.Data.Binding.DoNothing
		/// indicates that the binding does not transfer the value or use the System.Windows.Data.BindingBase.FallbackValue
		/// or the default value.</returns>
		public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double width = 0;

			// thumb + spacing = Position of category text
			double spaceLevel = 10 + 5;

			if( values[0] is int valLevel )
				width += -( valLevel * spaceLevel );

			if( values[1] is double valSplitter )
				width += valSplitter;

			return Math.Max( 0, width );
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts a binding target value to the source binding values.
		/// </summary>
		/// <param name="value">The value that the binding target produces</param>
		/// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types
		/// of values that are suggested for the method to return.</param>
		/// <param name="parameter">The converter parameter to use</param>
		/// <param name="culture">The culture to use in the converter</param>
		/// <returns>An array of values that have been converted from the target value back to the
		/// source values.</returns>
		public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
		{
			return null;
		}

		#endregion
	}
}
