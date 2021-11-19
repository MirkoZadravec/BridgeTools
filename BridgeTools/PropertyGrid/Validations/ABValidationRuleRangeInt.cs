//
// Copyright: (c) Allplan Infrastructure 2021
// ABValidationRuleRangeInt.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Globalization;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Validations
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Range rule.
	/// </summary>
	internal class ABValidationRuleRangeInt : ValidationRule
	{
		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Value range rule.
		/// </summary>
		private ABEnumRangeRule _range = ABEnumRangeRule.NO_LIMITS;

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Minimal value in user units.
		/// </summary>
		private int _min = ABRangeConst.INT_MIN;

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// >Maximal value in user units.
		/// </summary>
		private int _max = ABRangeConst.INT_MAX;

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Range rule.
		/// </summary>
		/// <param name="range">Value range rule</param>
		/// <param name="min">Minimal value in user units</param>
		/// <param name="max">Maximal value in user units</param>
		public ABValidationRuleRangeInt(
			ABEnumRangeRule range = ABEnumRangeRule.NO_LIMITS,
			int min = ABRangeConst.INT_MIN,
			int max = ABRangeConst.INT_MAX ) : base()
		{
			_range = range;
			_min = min;
			_max = max;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Validation.
		/// </summary>
		/// <param name="value">The value from the binding target to check</param>
		/// <param name="cultureInfo">The culture to use in this rule</param>
		/// <returns>A System.Windows.Controls.ValidationResult object</returns>
		public override ValidationResult Validate( object value, CultureInfo cultureInfo )
		{
			int parameter = 0;

			if( value is string s && s.Length > 0 )
			{
				if( !int.TryParse( s, out parameter ) )
				{
					return new ValidationResult( false, "Illegal characters." );
				}
			}

			if( _range == ABEnumRangeRule.MIN_MAX || _range == ABEnumRangeRule.MIN )
			{
				if( parameter < _min )
				{
					return new ValidationResult( false,
						"Please enter value in the range: "
						+ _min + " - " + _max + "." );
				}
			}

			if( _range == ABEnumRangeRule.MIN_MAX || _range == ABEnumRangeRule.MAX )
			{
				if( parameter > _max )
				{
					return new ValidationResult( false,
						"Please enter value in the range: "
						+ _min + " - " + _max + "." );
				}
			}

			return new ValidationResult( true, null );
		}
	}
}
