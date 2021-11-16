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

		#region Extend Comparison Methods

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Equals comparer for object text.
		/// </summary>
		/// <param name="obj">Object to compare</param>
		/// <returns>True if equals</returns>
		public override bool Equals( object obj )
		{
			if( obj is GroupItem<T> item )
			{
				return ObjText == item.ObjText;
			}

			if( obj is string text )
			{
				return ObjText == text;
			}

			return false;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Get hash code by object text.
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode()
		{
			return ObjText?.GetHashCode() ?? 0;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Operator == by object text.
		/// </summary>
		/// <param name="item1">First item</param>
		/// <param name="item2">Second item</param>
		/// <returns>True if equals</returns>
		public static bool operator ==( GroupItem<T> item1, GroupItem<T> item2 )
		{
			return item1?.ObjText == item2?.ObjText;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Operator != by object text.
		/// </summary>
		/// <param name="item1">First item</param>
		/// <param name="item2">Second item</param>
		/// <returns>True if differs</returns>
		public static bool operator !=( GroupItem<T> item1, GroupItem<T> item2 )
		{
			return !( item1 == item2 );
		}

		#endregion
	}
}
