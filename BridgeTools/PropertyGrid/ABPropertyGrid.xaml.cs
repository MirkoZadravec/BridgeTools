using BridgeTools.PropertyGrid.Categories;
using System.Windows.Controls;

// TODO
//   - Tooltips
//   - Validation Rules
//   * Tab stop
//   - IsVisible
//   - IsEnabled (do not forget to set opacity)
//   - Lost focus when closing prop grid
//   - Styles naming convention (for example see ABStyles)
//   - Comments

namespace BridgeTools.PropertyGrid
{
	/// <summary>
	/// Interaction logic for ABPropertyGrid.xaml
	/// </summary>
	public partial class ABPropertyGrid : UserControl
    {
        public ABPropertyGrid()
        {
            InitializeComponent();
        }

		public void Clear()
		{
			Container.Items.Clear();
		}

		public ABCat Root => Container;
	}
}
