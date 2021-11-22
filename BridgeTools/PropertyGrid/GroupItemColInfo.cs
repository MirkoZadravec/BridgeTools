//
// Copyright: (c) Allplan Infrastructure 2021
// GroupItemColInfo.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

namespace BridgeTools.PropertyGrid
{
	//------------------------------------------------------------------------------------------
	/// <summary>
	/// Column info.
	/// </summary>
	public class GroupItemColInfo
	{
		#region Properties

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Column text.
		/// </summary>
		public string Text { get; private set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Column width. First found column with with of doubleNaN auto-fills the remaining area.
		/// </summary>
		public double Width { get; private set; }

		#endregion

		#region Constructor

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="text">Column text</param>
		/// <param name="width">Column width. First found column with width of double.NaN 
		/// auto-fills the remaining area.</param>
		public GroupItemColInfo( 
			string text, 
			double width = double.NaN )
		{
			Text = text;
			Width = width;
		}

		#endregion
	}
}
