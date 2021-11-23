//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropertyGrid.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using abmControls.PropertyGrid.Categories;
using System.Windows.Controls;

namespace abmControls.PropertyGrid
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
