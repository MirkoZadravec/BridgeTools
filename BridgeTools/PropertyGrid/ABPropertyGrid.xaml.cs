//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropertyGrid.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using System.Windows.Controls;

// TODO
//   * Tooltips
//   - Validation Rules
//   * Tab stop
//   - IsVisible
//   - IsEnabled (do not forget to set opacity)
//   - Lost focus when closing prop grid
//   - Styles naming convention (for example see ABStyles)
//   * "varied" combo box situation
//   - Text for category is too high or expander too low

namespace BridgeTools.PropertyGrid
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Interaction logic for ABPropertyGrid.xaml
	/// </summary>
	public partial class ABPropertyGrid : UserControl
    {
		#region Properties

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Root container.
		/// </summary>
		public ABCat Root => Container;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public ABPropertyGrid()
        {
            InitializeComponent();
        }

		#endregion

		#region Public Methods

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Clear the property grid items.
		/// </summary>
		public void Clear()
		{
			Container.Items.Clear();
		}

		#endregion
	}
}
