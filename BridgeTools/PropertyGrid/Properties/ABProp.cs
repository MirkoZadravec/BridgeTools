//
// Copyright: (c) Allplan Infrastructure 2021
// ABProp.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Controls;
using BridgeTools.PropertyGrid.Resources;
using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Properties
{
    //----------------------------------------------------------------------------------------------
    /// <summary>
    /// Base property item class (control). 
    /// It represents the entire property grid row.
    /// Indent by depth level can be optionally ignored.
    /// </summary>
    public class ABProp : ListViewItem
    {
        #region Dependencies

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Level dependency property.
        /// </summary>
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(
            "Level", typeof( int ),
            typeof( ABProp )
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
                return parent != null ? parent.ParentLevel : 0;
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

        #region Styling

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Set initial style.
        /// </summary>
        /// <param name="parent">Parent category</param>
        /// <param name="noLevelIndent">True if no indent by depth level</param>
        protected void InitStyle( 
            ABCat parent, 
            bool noLevelIndent )
		{
            this.Style =
                noLevelIndent ?
                parent.FindResource( ABStyles.ABPropValFullRowStyle ) as Style :
                parent.FindResource( ABStyles.ABPropValStyle ) as Style;
        }

        #endregion
    }
}
