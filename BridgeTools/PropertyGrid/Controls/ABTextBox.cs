//
// Copyright: (c) Allplan Infrastructure 2021
// ABTextBox.cs
//
// Author: Mirko Zadravec
//

////////////////////////////
// NAMESPACES AND CLASSES //
////////////////////////////

using BridgeTools.PropertyGrid.Converters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BridgeTools.PropertyGrid.Controls
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// Custom text box.
	/// </summary>
	internal class ABTextBox : TextBox
	{
        #region Dependencies

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error border visibility dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowErrorBorderProperty = DependencyProperty.Register(
            nameof( ShowErrorBorder ), typeof( bool ),
            typeof( ABTextBox ), 
            new FrameworkPropertyMetadata( false )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error border visibility property.
        /// </summary>
        public bool ShowErrorBorder
        {
            get => (bool) GetValue( ShowErrorBorderProperty );
            set => SetValue( ShowErrorBorderProperty, value );
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error background visibility dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowErrorBackgroundProperty = DependencyProperty.Register(
            nameof( ShowErrorBackground ), typeof( bool ),
            typeof( ABTextBox ),
            new FrameworkPropertyMetadata( false )
            );

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Error background visibility property.
        /// </summary>
        public bool ShowErrorBackground
        {
            get => (bool) GetValue( ShowErrorBackgroundProperty );
            set => SetValue( ShowErrorBackgroundProperty, value );
        }

		#endregion

		#region Fields

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Initial focus and text selection.
		/// </summary>
		private bool _selectText = true;

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// True if lost focus should be processed after input.
		/// </summary>
		private bool _processLostFocus = false;

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// True if next property should get focus after TAB/ENTER press
		/// </summary>
		private bool _processNextFocus = true;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="selectText">Initial focus and text selection</param>
		/// <param name="processLostFocus">True if lost focus should be processed after input</param>
		/// <param name="processNextFocus">True if next property should get focus after TAB/ENTER press</param>
		public ABTextBox( 
            bool selectText = true,
            bool processLostFocus = false,
            bool processNextFocus = true ) : base()
		{
			_selectText = selectText;
			_processLostFocus = processLostFocus;
			_processNextFocus = processNextFocus;

			this.LostFocus += OnLostFocus;
            this.KeyDown += OnTextKeyDown;
            this.Loaded += OnTextBoxLoaded;
        }

		#endregion

		#region Public Methods

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Set focus and (optionally) select the text.
		/// </summary>
		/// <param name="selectText">Select the text</param>
		public void SetFocus( bool selectText )
		{
			if( selectText )
				this.SelectAll();
			this.Focusable = true;
			this.Focus();
			Keyboard.Focus( this );
		}

		#endregion

		#region Events

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Loaded event.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnTextBoxLoaded( object sender, RoutedEventArgs e )
		{
			// process initial focus and text selection
			if( !_selectText )
				return;

			SetFocus( _selectText );

			// this event is used only for initial load
			this.Loaded -= OnTextBoxLoaded;
		}

		//------------------------------------------------------------------------------------------
		/// <summary>
		/// Text key down event.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnTextKeyDown( object sender, KeyEventArgs e )
		{
			switch( e.Key )
			{
				case Key.Enter:
				case Key.Tab:
					{
						this.GetBindingExpression( TextBox.TextProperty ).UpdateSource();

						// select the text after ENTER press
						this.SelectAll();

						// forward as TAB

						var keyboardFocus = Keyboard.FocusedElement as UIElement;
						if( keyboardFocus != null && _processNextFocus )
							keyboardFocus.MoveFocus( new TraversalRequest( FocusNavigationDirection.Next ) );

						if( e.Key == Key.Tab )
							this.MoveFocus( new TraversalRequest( FocusNavigationDirection.Next ) );

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
		/// Lost focus event.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		private void OnLostFocus( object sender, RoutedEventArgs e )
		{
			if( !_processLostFocus )
				return;

			this.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		}

		#endregion
	}
}
