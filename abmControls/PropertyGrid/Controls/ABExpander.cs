//
// Copyright: (c) Allplan Infrastructure 2021
// ABExpander.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System.Windows;
using System.Windows.Controls;

namespace abmControls.PropertyGrid.Controls
{
    //----------------------------------------------------------------------------------------------
    /// <summary>
    /// Expander control.
    /// </summary>
    internal class ABExpander : Expander
    {
        #region Dependencies

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Level dependency property.
        /// </summary>
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(
            nameof( Level ), typeof( int ),
            typeof( ABExpander )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Level property.
        /// </summary>
        public int Level
        {
            get => (int) GetValue( LevelProperty );
            set => SetValue( LevelProperty, value );
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Parent level property.
        /// </summary>
        public int ParentLevel
        {
            get
            {
                var parent = GetParentExpander( this ) as ABExpander;
                return parent != null ? parent.ParentLevel + 1 : 0;
            }
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Child level property.
        /// </summary>
        public int ChildLevel => ParentLevel + 1;

        #endregion

        #region Helpers

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Recursively find parent expander control.
        /// </summary>
        /// <param name="child">Child control</param>
        /// <returns>Found parent control</returns>
        public DependencyObject GetParentExpander( FrameworkElement child )
        {
            if( child.Parent is ABExpander expander )
                return expander;

            if( child.Parent is FrameworkElement parent )
                return GetParentExpander( parent );

            return null;
        }

        #endregion
    }
}
