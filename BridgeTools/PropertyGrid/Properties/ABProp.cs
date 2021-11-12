using BridgeTools.PropertyGrid.Categories;
using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid.Properties
{
	public class ABProp : ListViewItem
    {
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(
            "Level", typeof( int ),
            typeof( ABProp )
            );

        public int Level
        {
            get => (int) GetValue( LevelProperty );
            set => SetValue( LevelProperty, value );
        }

        public int ParentLevel
        {
            get
            {
                var parent = GetParentExpander( this ) as ABExpander;
                return parent != null ? parent.ParentLevel : 0;
            }
        }

        public int ChildLevel => ParentLevel + 1;

        public DependencyObject GetParentExpander( FrameworkElement child )
        {
            if( child.Parent is ABExpander expander )
                return expander;

            if( child.Parent is FrameworkElement parent )
                return GetParentExpander( parent );

            return null;
        }

        protected void InitStyle( ABCat parent, bool noLevelIndent )
		{
            this.Style =
                noLevelIndent ?
                parent.FindResource( ABStyles.ABPropItemFullRowStyle ) as Style :
                parent.FindResource( ABStyles.ABPropItemLevelStyle ) as Style;
        }
    }
}
