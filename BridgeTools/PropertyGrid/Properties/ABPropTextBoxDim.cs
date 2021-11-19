//
// Copyright: (c) Allplan Infrastructure 2021
// ABPropTextBoxDim.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Categories;
using BridgeTools.PropertyGrid.Converters;
using BridgeTools.PropertyGrid.Resources;
using BridgeTools.PropertyGrid.Validations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BridgeTools.PropertyGrid.Properties
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Property with text box and dimension label (optional).
	/// </summary>
	/// <example>
	/// +------------+----------------------------------------------------+
	/// | Key label  | Editable text box     | Dimension label (optional) |
	/// +------------+----------------------------------------------------+
	/// </example>
	public class ABPropTextBoxDim : ABProp
	{
		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text edit field.
		/// </summary>
		private TextBox _textBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="symbol">Dimension symbol label (set null for no label)</param>
		public ABPropTextBoxDim(
			ABCat parent,
			string key,
			string symbol
			) : base()
		{
			InitStyle( parent, false );

			var dockPanel = new DockPanel()
			{
				LastChildFill = true,
			};

			var propKey = new TextBlock()
			{
				Text = key,
				Style = parent.FindResource( ABStyles.ABPropKeyStyle ) as Style,
			};
			DockPanel.SetDock( propKey, Dock.Left );
			dockPanel.Children.Add( propKey );

			var dockPanelVal = new DockPanel()
			{
				LastChildFill = true,
			};
			dockPanel.Children.Add( dockPanelVal );

			if( !string.IsNullOrEmpty( symbol ) )
			{
				var propSymbol = new TextBlock()
				{
					Text = symbol,
				};
				DockPanel.SetDock( propSymbol, Dock.Right );
				dockPanelVal.Children.Add( propSymbol );
			}

			_textBox = new TextBox()
			{
				Style = parent.FindResource( ABStyles.ABPropValTextBoxStyle ) as Style,
			};
			_textBox.LostFocus += OnLostFocus;
			_textBox.KeyDown   += OnTextKeyDown;
			_textBox.Loaded    += OnTextBoxLoaded;
			dockPanelVal.Children.Add( _textBox );

			parent.AddProperty( this, dockPanel );
		}

		#endregion

		#region Private Methods

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Set focus.
		/// </summary>
		/// <param name="selectText">Select the text</param>
		private void SetFocus( bool selectText )
		{
			if( _textBox == null )
				return;

			if( selectText )
				_textBox.SelectAll();
			_textBox.Focusable = true;
			_textBox.Focus();
			Keyboard.Focus( _textBox );
		}

		#endregion

		#region Events

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Get textbox control.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnTextBoxLoaded( object sender, RoutedEventArgs e )
		{
			bool _focus = true;
			bool _selectAll = true;

			if( !_focus )
				return;

			SetFocus( _selectAll );

			// this event is used only for initial load
			_textBox.Loaded -= OnTextBoxLoaded;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Text key down
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnTextKeyDown( object sender, KeyEventArgs e )
		{
			bool _processNextFocus = true; // TODO check if not set anywhere in AB

			if( _textBox == null )
				return;

			switch( e.Key )
			{
				case Key.Enter:
				case Key.Tab:
					{
						_textBox.GetBindingExpression( TextBox.TextProperty ).UpdateSource();

						// select the text after ENTER press
						_textBox.SelectAll();

						// forward as TAB

						var keyboardFocus = Keyboard.FocusedElement as UIElement;
						if( keyboardFocus != null && _processNextFocus )
							keyboardFocus.MoveFocus( new TraversalRequest( FocusNavigationDirection.Next ) );

						if( e.Key == Key.Tab )
							_textBox.MoveFocus( new TraversalRequest( FocusNavigationDirection.Next ) );

						// dont forward ENTER to the parent control (for example to avoid closing the dialog if OK is default button)

						e.Handled = true;
					}
					break;

				case Key.OemComma:
				case Key.Decimal:
					{
						e.Handled = ABConvDecimalComma.Forward();
					}
					break;
			}
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Processa lost focus.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnLostFocus( object sender, RoutedEventArgs e )
		{
			bool _processLostFocus = false;

			if( _textBox == null || !_processLostFocus )
				return;

			_textBox.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text box binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		/// <param name="range">Value range rule</param>
		/// <param name="min">Minimal value in user units (is considered depending on range rule)</param>
		/// <param name="max">Maximal value in user units (is considered depending on range rule)</param>
		public void BindText(
			object bSource,
			string bPath,
			ABEnumRangeRule range = ABEnumRangeRule.NO_LIMITS,
			double min = ABRangeConst.DOUBLE_MIN,
			double max = ABRangeConst.DOUBLE_MIN )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath ) 
			{ 
				Source = bSource,
				UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
				ValidatesOnExceptions = true,
				ValidatesOnDataErrors = true,
				// Hint: Use Validation.HasError trigger in style to show the validation message
			};

			if( range != ABEnumRangeRule.NO_LIMITS )
				b.ValidationRules.Add( new ABValidationRuleRangeDouble( range, min, max ) );

			_textBox.SetBinding( TextBox.TextProperty, b );

			// force the validation
			_textBox.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		}

		#endregion
	}
}
