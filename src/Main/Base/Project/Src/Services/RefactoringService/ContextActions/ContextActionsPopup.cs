﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Martin Konicek" email="martin.konicek@gmail.com"/>
//     <version>$Revision: $</version>
// </file>
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using ICSharpCode.SharpDevelop.Editor;

namespace ICSharpCode.SharpDevelop.Refactoring
{
	/// <summary>
	/// Description of ContextActionsPopup.
	/// </summary>
	public class ContextActionsPopup : ContextActionsPopupBase
	{
		public ContextActionsPopup()
		{
			// Close on lost focus
			this.StaysOpen = false;
			this.AllowsTransparency = true;
			this.ActionsControl = new ContextActionsHeaderedControl();
			// Close when any action excecuted
			this.ActionsControl.ActionExecuted += delegate { this.Close(); };
		}
		
		public ContextActionsHeaderedControl ActionsControl
		{
			get { return (ContextActionsHeaderedControl)this.Child; }
			set { this.Child = value; }
		}
		
		public ContextActionsViewModel Actions
		{
			get { return (ContextActionsViewModel)ActionsControl.DataContext; }
			set { 
				ActionsControl.DataContext = value; 
			}
		}
		
		public new void Focus()
		{
			this.ActionsControl.Focus();
		}
		
		public void OpenAtCaretAndFocus()
		{
			OpenAtMousePosition();
			//OpenAtPosition(editor, editor.Caret.Line, editor.Caret.Column, true);
			this.Focus();
		}
		
		void OpenAtMousePosition()
		{
			this.Placement = PlacementMode.MousePoint;
			this.Open();
		}
	}
}
