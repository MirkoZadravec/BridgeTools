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

		public List<GroupItemMulti<int>> ComboOptionsMulti = new List<GroupItemMulti<int>>()
		{
			new GroupItemMulti<int>( 10,  new List<string>() { 10.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 20,  new List<string>() { 20.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 30,  new List<string>() { 30.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 40,  new List<string>() { 40.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 50,  new List<string>() { 50.ToString(), "[in]" } ),
			new GroupItemMulti<int>( 60,  new List<string>() { 60.ToString(), "[in]" } ),
			new GroupItemMulti<int>( 70,  new List<string>() { 70.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 80,  new List<string>() { 80.ToString(), "[in]" } ),
			new GroupItemMulti<int>( 90,  new List<string>() { 90.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 100,  new List<string>() { 100.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 110,  new List<string>() { 110.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 120,  new List<string>() { 120.ToString(), "[m]" } ),
			new GroupItemMulti<int>( 130,  new List<string>() { 130.ToString(), "[m]" } ),
		};
		private GroupItemMulti<int> _comboOptionMulti = null;
		public GroupItemMulti<int> ComboOptionMulti
		{
			get { return _comboOptionMulti; }
			set
			{
				_comboOptionMulti = value;
				OnPropertyChanged( nameof( ComboOptionMulti ) );
			}
		}

		public void InitComboOptionMulti( GroupItemMulti<int> comboOptionMulti )
		{
			_comboOptionMulti = comboOptionMulti;
		}
	}
}
