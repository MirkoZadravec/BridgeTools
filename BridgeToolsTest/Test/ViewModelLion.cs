//
// Copyright: (c) Allplan Infrastructure 2021
// ViewModelLion.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid;
using System.Collections.Generic;

namespace BridgeToolsTest.Test
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelLion : ViewModelAnimal
	{
		public List<GroupItem<ComboOptionsEnum>> ComboOptions = new List<GroupItem<ComboOptionsEnum>>()
		{
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.First, "First" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Second, "Second" ),
			new GroupItem<ComboOptionsEnum>( ComboOptionsEnum.Third, "Third" )
		};
		private GroupItem<ComboOptionsEnum> _comboOption = null;
		public GroupItem<ComboOptionsEnum> ComboOption
		{
			get { return _comboOption; }
			set
			{
				_comboOption = value;
				OnPropertyChanged( nameof( ComboOption ) );
			}
		}

		public void InitComboOption( GroupItem<ComboOptionsEnum> comboOption )
		{
			_comboOption = comboOption;
		}
	}
}
