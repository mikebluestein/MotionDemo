using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace MotionDemo
{
	public partial class MotionDemoViewController : UIViewController
	{
		public MotionDemoViewController () : base ("MotionDemoViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var xCenterEffect = new UIInterpolatingMotionEffect ("center.x", UIInterpolatingMotionEffectType.TiltAlongHorizontalAxis) {
				MinimumRelativeValue = new NSNumber (25),
				MaximumRelativeValue = new NSNumber (-25)
			};

			var yCenterEffect = new UIInterpolatingMotionEffect ("center.y", UIInterpolatingMotionEffectType.TiltAlongVerticalAxis) {
				MinimumRelativeValue = new NSNumber (75),
				MaximumRelativeValue = new NSNumber (-75)
			};

			var skewEffect = new UIInterpolatingMotionEffect ("layer.transform", UIInterpolatingMotionEffectType.TiltAlongVerticalAxis) {
				MinimumRelativeValue = NSObject.FromObject (Skew (-1.0f)),
				MaximumRelativeValue = NSObject.FromObject (Skew (1.0f)),
			};

			var effectGroup = new UIMotionEffectGroup {
				MotionEffects = new []{ xCenterEffect, yCenterEffect, skewEffect }
			};

			monkeyView.AddMotionEffect (effectGroup);
		}

		CATransform3D Skew (float x)
		{
			var transform = CATransform3D.Identity;
			transform.m34 = 1.0f / 1000;
			return transform.Rotate (60.0f * (float)Math.PI / 180.0f, x, 0, 0);
		}
	}
}

