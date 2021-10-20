using System;
using System.Windows;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid
{
	//------------------------------------------------------------------------------------------
	/// <summary>
	/// Radio buttons convertor
	/// </summary>
	internal class ABRadioConverter : IValueConverter
	{
		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Convert
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="targetType">Type</param>
		/// <param name="parameter">parameter</param>
		/// <param name="culture">CultureInfo</param>
		/// <returns>Result</returns>
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
		/// Convert back
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="targetType">Type</param>
		/// <param name="parameter">parameter</param>
		/// <param name="culture">CultureInfo</param>
		/// <returns>Result</returns>
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
