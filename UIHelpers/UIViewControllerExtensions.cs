using CoreAnimation;
using CoreGraphics;
using System;
using UIKit;

namespace UIHelpers
{
    public static class UIViewControllerExtensions
    {
        public static CAGradientLayer CreateBackgroundGradient(this UIViewController controller, UIColor color1, UIColor color2, int placeInIndex)
        {
            var gradient = controller.CreateBackgroundGradient(color1, color2);
            controller.View.Layer.InsertSublayer(gradient, placeInIndex);
            return gradient;
        }

        public static CAGradientLayer CreateBackgroundGradient(this UIViewController controller, UIColor color1, UIColor color2)
        {
            var gradient = new CAGradientLayer
            {
                Frame = controller.View.Bounds,
                NeedsDisplayOnBoundsChange = true,
                MasksToBounds = true,
                Colors = new[] { color1.CGColor, color2.CGColor }
            };
            return gradient;
        }
    }
}