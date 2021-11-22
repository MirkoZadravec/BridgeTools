//
// Copyright: (c) Allplan Infrastructure 2021
// ViewModelPiers.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

namespace BridgeToolsTest.Test
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelPiers : ViewModelBase
	{
		public string Project { get; set; }
		public ViewModelPier Pier1 { get; set; } = new ViewModelPier()
		{
			Name = "Pier 1",
			Description = "Long pier",
			Offset = "7,1",
			IsDone = false,
			IsReady = false,
			IsEnabledReady = false,
			IsEnabled = true,
		};
		public ViewModelPier Pier2 { get; set; } = new ViewModelPier()
		{
			Name = "Pier 2",
			Description = "Short pier",
			Offset = "5",
			IsDone = true,
			IsReady = null,
			IsEnabledReady = false,
			IsEnabled = true,
		};
	}
}
