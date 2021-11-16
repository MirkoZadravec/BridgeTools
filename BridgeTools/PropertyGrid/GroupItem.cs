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
	/// Group item class.
	/// Connects object with representation text.
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
		/// Object representation text
		/// </summary>
		public string ObjText { get; set; }

		#endregion

		#region Constructor

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="obj">Object</param>
		/// <param name="objText">Object text</param>
		public GroupItem( T obj, string objText )
		{
			Obj = obj;
			ObjText = objText;
		}

		#endregion
	}
}
