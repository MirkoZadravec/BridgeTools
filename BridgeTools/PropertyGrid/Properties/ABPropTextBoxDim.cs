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
using BridgeTools.PropertyGrid.Controls;
using BridgeTools.PropertyGrid.Resources;
using BridgeTools.PropertyGrid.Validations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
		private ABTextBox _textBox = null;

		#endregion

		#region Constructor

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">Parent category</param>
		/// <param name="key">Property key label</param>
		/// <param name="symbol">Dimension symbol label (set null for no label)</param>
		/// <param name="readOnly">Initial read-only state</param>
		/// <param name="selectText">Initial focus and text selection</param>
		/// <param name="processLostFocus">True if lost focus should be processed after input</param>
		/// <param name="processNextFocus">True if next property should get focus after TAB/ENTER press</param>
		public ABPropTextBoxDim(
			ABCat parent,
			string key,
			string symbol,
			bool readOnly = false,
			bool selectText = true,
			bool processLostFocus = false,
			bool processNextFocus = true
			) : base()
		{
			InitStyle( parent, false );

			this.IsEnabled = !readOnly;

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
					Style = parent.FindResource( ABStyles.ABPropValDimTextBlockStyle ) as Style,
				};
				DockPanel.SetDock( propSymbol, Dock.Right );
				dockPanelVal.Children.Add( propSymbol );
			}

			_textBox = new ABTextBox( selectText, processLostFocus, processNextFocus )
			{
				Style = parent.FindResource( ABStyles.ABPropValTextBoxStyle ) as Style,
			};
			dockPanelVal.Children.Add( _textBox );

			parent.AddProperty( this, dockPanel );
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
			// TODO check if we really need this...

			if( _textBox == null )
				return;

			_textBox.SetFocus( selectText );
		}

		#endregion

		#region Bindings

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Text box binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindText(
			object bSource,
			string bPath )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource,
				UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
			};

			_textBox.SetBinding( TextBox.TextProperty, b );
		}

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
			ABEnumRangeRule range,
			double min,
			double max )
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
			ABEnumRangeRule range,
			int min,
			int max )
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
				b.ValidationRules.Add( new ABValidationRuleRangeInt( range, min, max ) );

			_textBox.SetBinding( TextBox.TextProperty, b );

			// force the validation
			_textBox.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Error border binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindShowErrorBorder(
			object bSource,
			string bPath)
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource,
			};

			_textBox.SetBinding( ABTextBox.ShowErrorBorderProperty, b );
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Error background binding.
		/// </summary>
		/// <param name="bSource">Source object</param>
		/// <param name="bPath">Property path</param>
		public void BindShowErrorBackground(
			object bSource,
			string bPath )
		{
			if( null == _textBox )
				return;

			if( null == bSource || string.IsNullOrEmpty( bPath ) )
				return;

			var b = new Binding( bPath )
			{
				Source = bSource,
			};

			_textBox.SetBinding( ABTextBox.ShowErrorBackgroundProperty, b );
		}

		#endregion
	}
}
