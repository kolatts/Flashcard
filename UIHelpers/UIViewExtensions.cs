using CoreGraphics;
using System;
using UIKit;

namespace UIHelpers
{
    public static class UIViewExtensions
    {
    }

    public static class UITextViewExtensions
    {
    }

    public static class DropShadows
    {
        public static void AddDropShadow(this UITextView t, UIColor color = null, float offsetHorizontal = 0, float offsetVertical = 2, float opacity = 0.5f)
        {
            t.Layer.MasksToBounds = false;
            t.Layer.ShadowColor = (color ?? UIColor.Black).CGColor;
            t.Layer.ShadowOffset = new CGSize(offsetHorizontal, offsetVertical);
            t.Layer.ShadowOpacity = opacity;
        }

        public static void AddDropShadow(this UIButton b, UIColor color = null, UIControlState whenInState = UIControlState.Normal, float offsetHorizontal = 0,
            float offsetVertical = 2)
        {
            b.Layer.MasksToBounds = false;
            b.SetTitleShadowColor((color ?? UIColor.Black), whenInState);
            b.TitleShadowOffset = new CGSize(offsetHorizontal, offsetVertical);
        }
    }
}