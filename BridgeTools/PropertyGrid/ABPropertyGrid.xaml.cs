using System.Windows.Controls;

// TODO
//   - Tooltips
//   - Validation Rules
//   - Color picker
//   * Tab stop
//   - Visibility
//   - IsEnabled

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
			Root.Items.Clear();
		}

		public ABCategory AddCategory(
			string key,
			bool isExpanded )
		{
			return Root.AddCategory( key, isExpanded );
		}
	}
}
