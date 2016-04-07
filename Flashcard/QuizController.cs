using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Flashcard.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using CoreAnimation;
using System.ComponentModel;
using UIHelpers;
namespace Flashcard
{
	partial class QuizController : UIViewController
	{
        public Quiz Quiz { get; set; }
        public int QuestionIndex { get; set; }
        public IAnswerable CurrentQuestion => Quiz.Questions[QuestionIndex];
        public CoreGraphics.CGGradient BackgroundGradient {get;set;} 

        public int redValue = 66;
        public int greenValue = 69;
        public int index = 0;
		public QuizController (IntPtr handle) : base (handle)
		{
            LocalData.Instance.Quiz = new Quiz(true);
            Quiz = LocalData.Instance.Quiz;
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AnswerClock.TextColor = UIColor.White;
            QuestionText.TextColor = UIColor.White;
            LabelValidation.Text = string.Empty;
            AnswerInput.TextColor = UIColor.White;
            ButtonNext.SetTitleColor(UIColor.White, UIControlState.Normal);
            ButtonNext.SetTitleShadowColor(UIColor.Black, UIControlState.Normal);
            ButtonNext.TitleShadowOffset = new CGSize(0, 2);
            ButtonNext.Layer.MasksToBounds = false;
            QuestionText.Layer.MasksToBounds = false;
            QuestionText.Layer.ShadowColor = UIColor.Black.CGColor;
            QuestionText.Layer.ShadowOffset = new CGSize(0, 2);
            QuestionText.Layer.ShadowOpacity = 0.5f;
            LoadQuestion();
            Quiz.Started = DateTimeOffset.Now;
        }



        public async void UpdateClockLabel()
        {
            if (Quiz.TimeRemaining <= TimeSpan.FromTicks(0))
                Finish();
            if (AnswerClock.Text != CurrentQuestion.TimeInSeconds)
            {
                AnswerClock.Text = $"{Quiz.TimeRemaining.Minutes}:{Quiz.TimeRemaining.Seconds:00}";
                AnswerInput.BecomeFirstResponder();
            }
            await Task.Delay(1000);
            UpdateClockLabel();
        }

        protected void LoadQuestion()
        {
            this.CreateBackgroundGradient(UIColor.FromRGB(redValue, greenValue, 252), UIColor.FromRGB(0, 3, 189), index++);
            QuestionText.Text = Quiz.Questions[QuestionIndex].Text;
            AnswerInput.Text = string.Empty;
            CurrentQuestion.Started = DateTimeOffset.Now;
            UpdateClockLabel();
        }

        partial void OnNextTouchUpInside(UIButton sender)
        {
            EvaluateAnswer(AnswerInput.Text);
        }

        protected async void FlashValidation()
        {
            LabelValidation.Text = "Enter valid number.";
            await Task.Delay(3000);
            LabelValidation.Text = string.Empty;
        }
        protected async void FlashFeedback(string m, UIColor color)
        {
            LabelValidation.Text = m;
            LabelValidation.TextColor = color;
            await Task.Delay(3000);
            LabelValidation.Text = string.Empty;
        }
      

        protected void EvaluateAnswer(string answer)
        {
            var result = CurrentQuestion.Answer(AnswerInput.Text);

            switch(result)
            {
                case null:
                    FlashFeedback("Enter valid number.", UIColor.Yellow);
                    break;
                case true:
                    
                    FlashFeedback("Correct!", UIColor.Green);
                    greenValue = greenValue + (255 - greenValue) / 2;
                    redValue = redValue - (redValue) / 2;
                    LoadNext();
                    break;
                case false:
                    FlashFeedback("Incorrect. Correct answer was " + CurrentQuestion.CorrectAnswer, UIColor.Red);
                    redValue = redValue + (255 - redValue) / 2;
                    greenValue = greenValue - (greenValue) / 2;
                    LoadNext();
                    break;
            }
        }

        protected void Finish()
        {
            AnswerInput.Hidden = true;
            QuestionText.Hidden = true;
            AnswerClock.Hidden = true;
            ButtonNext.Hidden = true;
            FinishButton.Hidden = true;
            FinishButton.Hidden = true;
        }

        protected void LoadNext()
        {
            if (QuestionIndex == Quiz.Questions.Count - 1)
            {
                Quiz.GenerateMoreQuestions();
            }
                QuestionIndex++;
                LoadQuestion();
        }


        partial void OnGo(UITextField sender)
        {
            OnNextTouchUpInside(null);
        }



	}
}
