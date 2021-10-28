using System.Windows.Controls;

// TODO
//   - Tooltips
//   - Validation Rules
//   - Color picker
//   * Tab stop
//   - IsVisible
//   - IsEnabled (do not forget to set opacity)
//   - Lost focus when closing prop grid

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
			bool isExpanded,
			object bSource,
			string bPathEnabled,
			string bPathEnabledChildren )
		{
			return Root.AddCategory( key, isExpanded, bSource, bPathEnabled, bPathEnabledChildren );
		}
	}
}
