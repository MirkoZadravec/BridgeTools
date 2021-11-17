//
// Copyright: (c) Allplan Infrastructure 2021
// ViewModelGeoPos.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using System;
using System.Windows.Input;
using System.Windows.Media;

namespace BridgeToolsTest.Test
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Custom commands (global).
	/// </summary>
	public static class CCustomCommands
	{
	}

	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// View model for testing.
	/// </summary>
	public class ViewModelGeoPos : ViewModelBase
	{
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public bool IsEnabledDate { get; set; } = true;
		public Color Color { get; set; }

		#region Commands

		public static readonly RoutedUICommand ButtonCmd = new RoutedUICommand
		(
			"My command",
			nameof( ButtonCmd ),
			typeof( CCustomCommands )
		);

		public void ButtonCmd_CanExecute( object sender, CanExecuteRoutedEventArgs e )
		{
			e.CanExecute = true;
		}

		public void ButtonCmd_Executed( object sender, ExecutedRoutedEventArgs e )
		{
			e.Handled = true;

			System.Windows.MessageBox.Show( "OK" );
		}

		#endregion
	}
}
