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

		public List<GroupItemMulti<ComboOptionsEnum>> ComboOptionsMulti = new List<GroupItemMulti<ComboOptionsEnum>>()
		{
			new GroupItemMulti<ComboOptionsEnum>( ComboOptionsEnum.First,  new List<string>() { "First",  "[m]" } ),
			new GroupItemMulti<ComboOptionsEnum>( ComboOptionsEnum.Second, new List<string>() { "Second", "[in]" } ),
			new GroupItemMulti<ComboOptionsEnum>( ComboOptionsEnum.Third,  new List<string>() { "Third",  "[m]" } )
		};
		private GroupItemMulti<ComboOptionsEnum> _comboOptionMulti = null;
		public GroupItemMulti<ComboOptionsEnum> ComboOptionMulti
		{
			get { return _comboOptionMulti; }
			set
			{
				_comboOptionMulti = value;
				OnPropertyChanged( nameof( ComboOptionMulti ) );
			}
		}

		public void InitComboOptionMulti( GroupItemMulti<ComboOptionsEnum> comboOptionMulti )
		{
			_comboOptionMulti = comboOptionMulti;
		}
	}
}
