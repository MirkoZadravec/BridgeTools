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
        /// Error border visibility dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowErrorBorderProperty = DependencyProperty.Register(
            nameof( ShowErrorBorder ), typeof( bool ),
            typeof( ABTextBox ), 
            new FrameworkPropertyMetadata( false )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error border visibility property.
        /// </summary>
        public bool ShowErrorBorder
        {
            get => (bool) GetValue( ShowErrorBorderProperty );
            set => SetValue( ShowErrorBorderProperty, value );
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error background visibility dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowErrorBackgroundProperty = DependencyProperty.Register(
            nameof( ShowErrorBackground ), typeof( bool ),
            typeof( ABTextBox ),
            new FrameworkPropertyMetadata( false )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error background visibility property.
        /// </summary>
        public bool ShowErrorBackground
        {
            get => (bool) GetValue( ShowErrorBackgroundProperty );
            set => SetValue( ShowErrorBackgroundProperty, value );
        }

        #endregion
    }
}
