using System;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Converters
{
	internal class ABConvLevelToOffset : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			// thumb + spacing = Position of category text
			double spaceLevel = 10 + 5;

			if( value is int valLevel )
				return valLevel * spaceLevel;

			return 0;
		}

		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			return 0;
		}
	}
}
