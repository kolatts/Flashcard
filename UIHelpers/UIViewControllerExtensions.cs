using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace UIHelpers
{
    public static class UIViewControllerExtensions
    {
        public static CAGradientLayer CreateBackgroundGradient(this UIViewController controller,UIColor color1, UIColor color2, int placeInIndex)
        {
            var gradient = controller.CreateBackgroundGradient(color1, color2);
            controller.View.Layer.InsertSublayer (gradient, placeInIndex);
            return gradient;
        }

        public static CAGradientLayer CreateBackgroundGradient(this UIViewController controller, UIColor color1, UIColor color2)
        {
            var gradient = new CAGradientLayer();
            gradient.Frame = controller.View.Bounds;
            gradient.NeedsDisplayOnBoundsChange = true;
            gradient.MasksToBounds = true;
            gradient.Colors = new CGColor[]{ color1.CGColor, color2.CGColor };
            return gradient;
        }

    }
}

