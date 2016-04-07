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
	[Register ("QuizSummary")]
	partial class QuizSummary
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel QuizResults { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (QuizResults != null) {
				QuizResults.Dispose ();
				QuizResults = null;
			}
		}
	}
}
