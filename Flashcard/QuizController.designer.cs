// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Flashcard
{
	[Register ("QuizController")]
	partial class QuizController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AnswerClock { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AnswerInput { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ButtonNext { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton FinishButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LabelValidation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView QuestionText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView QuizBackground { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SpecialCharacterButton { get; set; }

		[Action ("OnGo:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnGo (UITextField sender);

		[Action ("OnKeypadButtonTouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnKeypadButtonTouchUpInside (UIButton sender);

		[Action ("OnNextTouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnNextTouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (AnswerClock != null) {
				AnswerClock.Dispose ();
				AnswerClock = null;
			}
			if (AnswerInput != null) {
				AnswerInput.Dispose ();
				AnswerInput = null;
			}
			if (ButtonNext != null) {
				ButtonNext.Dispose ();
				ButtonNext = null;
			}
			if (FinishButton != null) {
				FinishButton.Dispose ();
				FinishButton = null;
			}
			if (LabelValidation != null) {
				LabelValidation.Dispose ();
				LabelValidation = null;
			}
			if (QuestionText != null) {
				QuestionText.Dispose ();
				QuestionText = null;
			}
			if (QuizBackground != null) {
				QuizBackground.Dispose ();
				QuizBackground = null;
			}
			if (SpecialCharacterButton != null) {
				SpecialCharacterButton.Dispose ();
				SpecialCharacterButton = null;
			}
		}
	}
}
