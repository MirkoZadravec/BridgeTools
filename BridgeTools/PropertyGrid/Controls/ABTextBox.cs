//
// Copyright: (c) Allplan Infrastructure 2021
// ABTextBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Controls
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Custom text box.
	/// </summary>
	internal class ABTextBox : TextBox
	{
        #region Dependencies

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error state dependency property.
        /// </summary>
        public static readonly DependencyProperty ErrorStateProperty = DependencyProperty.Register(
            nameof( ErrorState ), typeof( ABTextErrorState ),
            typeof( ABTextBox ), 
            new FrameworkPropertyMetadata( ABTextErrorState.NONE )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error state property.
        /// </summary>
        public ABTextErrorState ErrorState
        {
            get => (ABTextErrorState) GetValue( ErrorStateProperty );
            set => SetValue( ErrorStateProperty, value );
        }

        #endregion
    }
}
