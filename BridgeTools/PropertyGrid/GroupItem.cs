//
// Copyright: (c) Allplan Infrastructure 2021
// GroupItem.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

namespace BridgeTools.PropertyGrid
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Group item class used for combo box, radio box, etc.
	/// The item connects object with its representation text.
	/// </summary>
	/// <typeparam name="T">Item object type</typeparam>
	public class GroupItem<T>
	{
		#region Properties

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object.
		/// </summary>
		public T Obj { get; private set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object representation text.
		/// </summary>
		public string ObjText { get; set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Object representation info (tooltip etc).
		/// </summary>
		public string ObjInfo { get; set; }

		#endregion

		#region Constructor

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="obj">Object</param>
		/// <param name="objText">Object text</param>
		/// <param name="objInfo">Object info (tooltip etc) - optional</param>
		public GroupItem( T obj, string objText, string objInfo = null )
		{
			Obj = obj;
			ObjText = objText;
			ObjInfo = objInfo;
		}

		#endregion
	}
}
