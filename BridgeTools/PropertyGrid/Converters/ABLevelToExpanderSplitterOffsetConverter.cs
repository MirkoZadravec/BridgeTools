using System;
using System.Windows.Data;

namespace BridgeTools.PropertyGrid.Converters
{
	internal class ABLevelToExpanderSplitterOffsetConverter : IMultiValueConverter
	{
		#region IMultiValueConverter Members

		public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			double width = 0;

			// thumb + spacing = Position of category text
			double spaceLevel = 10 + 5;

			if( values[0] is int valLevel )
				width += -( ( valLevel + 1 ) * spaceLevel );

			if( values[1] is double valSplitter )
				width += valSplitter;

			return Math.Max( 0, width );
		}

		public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
		{
			return null;
		}

		#endregion
	}
}
