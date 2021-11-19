//
// Copyright: (c) Allplan Infrastructure 2021
// ABRange.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

namespace BridgeTools.PropertyGrid.Validations
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Range constants.
	/// </summary>
	public static class ABRangeConst
	{
		public const double DOUBLE_MAX = 1.0e+100;
		public const double DOUBLE_MIN = -1.0e+100;
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Range rule enum.
	/// </summary>
	public enum ABEnumRangeRule
	{
		NO_LIMITS,
		MIN,
		MAX,
		MIN_MAX
	}
}
