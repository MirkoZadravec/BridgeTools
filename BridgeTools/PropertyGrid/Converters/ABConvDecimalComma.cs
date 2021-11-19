//
// Copyright: (c) Allplan Infrastructure 2021
// ABConvDecimalComma.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Globalization;
using System.Windows.Input;

namespace BridgeTools.PropertyGrid.Converters
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Converter.
	/// </summary>
	public class ABConvDecimalComma
	{
		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Forward ',' as '.' press event.
		/// Fixing NumBlock-Decimal-To-NumberDecimalSeparator conversion
		/// from: https://stackoverflow.com/questions/3810904/keypad-decimal-separator-on-a-wpf-textbox-how-to
		/// </summary>
		/// <param name="checkSeparatorLength"></param>
		/// <returns></returns>
		public static bool Forward( bool checkSeparatorLength = false )
		{
			if( checkSeparatorLength &&
				CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Length == 0 )
			{
				return false;
			}

			Keyboard.FocusedElement.RaiseEvent
			(
				new TextCompositionEventArgs
				(
					InputManager.Current.PrimaryKeyboardDevice,
					new TextComposition
					(
						InputManager.Current,
						Keyboard.FocusedElement,
						CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
					)
				)
				{
					RoutedEvent = TextCompositionManager.TextInputEvent
				}
			);

			return true;
		}
	}
}
