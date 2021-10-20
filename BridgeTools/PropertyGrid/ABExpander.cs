using System.Windows;
using System.Windows.Controls;

namespace BridgeTools.PropertyGrid
{
    public class ABExpander : Expander
    {
        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(
            "Level", typeof( int ),
            typeof( ABExpander )
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
                return parent != null ? parent.ParentLevel + 1 : 0;
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
    }
}
