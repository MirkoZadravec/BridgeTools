//
// Copyright: (c) Allplan Infrastructure 2021
// ViewModelBase.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System;
using System.ComponentModel;

namespace BridgeToolsTest.Test
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	///  Abstract base class for all ViewModel classes in the application. It provides
	///  support for property change notifications and has a DisplayName property.
	///  Optionally it allows for disposing (native) data.
	/// </summary>
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		#region Construction

		//------------------------------------------------------------------------------------------
		protected ViewModelBase() { }

		#endregion // Construction

		#region INotifyPropertyChanged Members

		/// <summary> Raised when a property on this object has a new value.</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		//------------------------------------------------------------------------------------------
		/// <summary> Raises this object's PropertyChanged event.</summary>
		/// <param name="propertyName"> [in] The property that has a new value.</param>
		protected void NotifyPropertyChanged( string propertyName )
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		//------------------------------------------------------------------------------------------
		// TODO: replace calls with NotifyPropertyChanged and then remove.
		protected void OnPropertyChanged( string propertyName )
		{
			NotifyPropertyChanged( propertyName );
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		///  Notifies all relevant properties for this object.
		///  Sub-classes MUST override this function!
		/// </summary>
		protected virtual void NotifyPropertyChangedAll()
		{
			// IDEA: get the property collection to notify all properties
			//if( _propCollection == null )
			//	_propCollection = TypeDescriptor.GetProperties( this );

			//if( _propCollection?.Count > 0 )
			//{
			//	foreach( PropertyDescriptor prop in _propCollection )
			//	{
			//		PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop.Name ) );
			//	}
			//}

#if DEBUG
			throw new NotImplementedException( "Function must be overridden in sub-class!" );
#endif
		}

		#endregion // INotifyPropertyChanged Members
	}
}
