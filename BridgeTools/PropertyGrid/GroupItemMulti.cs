//
// Copyright: (c) Allplan Infrastructure 2021
// GroupItemMulti.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Collections.Generic;

namespace BridgeTools.PropertyGrid
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Group item class used for combo box, radio box, etc.
	/// The item connects object with its representation text.
	/// </summary>
	/// <typeparam name="T">Item object type</typeparam>
	public class GroupItemMulti<T>
	{
		#region Properties

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object.
		/// </summary>
		public T Obj { get; private set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object representation texts (multi-column combo box etc).
		/// </summary>
		public List<string> ObjTexts { get; private set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object representation info (tooltip etc).
		/// </summary>
		public string ObjInfo { get; private set; }

		#endregion

		#region Constructor

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="obj">Object</param>
		/// <param name="objTexts">Object texts (multi-column combo box etc)</param>
		/// <param name="objInfo">Object info (tooltip etc) - optional</param>
		public GroupItemMulti( T obj, List<string> objTexts, string objInfo = null )
		{
			Obj = obj;
			ObjTexts = objTexts;
			ObjInfo = objInfo;
		}

		#endregion
	}
}
