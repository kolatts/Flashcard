using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;
using CoreAnimation;
using CoreGraphics;

namespace Flashcard
{
	partial class QuizSummary : UIViewController
	{

        protected CAGradientLayer gradient;
		public QuizSummary (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var quiz = LocalData.Instance.Quiz;
            var correct = quiz.Questions.Count(x => x.AnsweredCorrectly);
            var incorrect = quiz.Questions.Count(x => x.AnsweredCorrectly == false);
            var totalTime = quiz.Questions.Select(x => x.CompletionTime).Aggregate((x, y) => x + y).GetValueOrDefault();
            QuizResults.Text = $"{correct} Correct answers. {incorrect} Incorrect answers. {totalTime.Minutes}m , {totalTime.Seconds}s.";
        }

        public void DrawBackground()
        {
            gradient = new CAGradientLayer();
            gradient.Frame = View.Bounds;
            gradient.NeedsDisplayOnBoundsChange = true;
            gradient.MasksToBounds = true;
            gradient.Colors = new CGColor[]{ UIColor.FromRGB(69,63,252).CGColor, UIColor.FromRGB(0,3,189).CGColor };
            View.Layer.InsertSublayer (gradient, 0);

        }
	}
}
