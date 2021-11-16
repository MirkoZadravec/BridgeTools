namespace BridgeTools.PropertyGrid
{
	public class GroupItem<T>
	{
		//------------------------------------------------------------------------------------------
		public T Obj { get; private set; }

		//------------------------------------------------------------------------------------------
		public string ObjText { get; set; }

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// CTor comboitem
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="objText"></param>
		public GroupItem( T obj, string objText )
		{
			Obj = obj;
			ObjText = objText;
		}

		#region Extend Comparison Methods

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Equals
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
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
		/// Get hash code.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return ObjText?.GetHashCode() ?? 0;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Operator ===
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static bool operator ==( GroupItem<T> item1, GroupItem<T> item2 )
		{
			return item1?.ObjText == item2?.ObjText;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Opüeratr
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static bool operator !=( GroupItem<T> item1, GroupItem<T> item2 )
		{
			return !( item1 == item2 );
		}

		#endregion
	}
}
