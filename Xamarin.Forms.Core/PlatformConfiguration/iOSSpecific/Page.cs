using UIKit;

namespace Xamarin.Forms.PlatformConfiguration.iOSSpecific
{
	using FormsElement = Forms.Page;

	public static class Page
	{
		public enum PageUIStatusBarAnimation
		{
			None,
			Slide,
			Fade,
		}

		public static readonly BindableProperty PrefersStatusBarHiddenProperty =
			BindableProperty.Create("PrefersStatusBarHidden", typeof(bool), typeof(Page),
			// >= iOS 8.0 and in some form of portrait; see: https://developer.apple.com/reference/uikit/uiviewcontroller/1621440-prefersstatusbarhidden
			(UIDevice.CurrentDevice.CheckSystemVersion(8, 0) &&
			(UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft ||
			 UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight)) ? true : false);

		public static bool GetPrefersStatusBarHidden(BindableObject element)
		{
			return (bool)element.GetValue(PrefersStatusBarHiddenProperty);
		}

		public static void SetPrefersStatusBarHidden(BindableObject element, bool value)
		{
			element.SetValue(PrefersStatusBarHiddenProperty, value);
		}

		public static bool PrefersStatusBarHidden(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetPrefersStatusBarHidden(config.Element);
		}

		public static IPlatformElementConfiguration<iOS, FormsElement> SetPrefersStatusBarHidden(this IPlatformElementConfiguration<iOS, FormsElement> config, bool value)
		{
			SetPrefersStatusBarHidden(config.Element, value);
			return config;
		}

		public static readonly BindableProperty PreferredStatusBarUpdateAnimationProperty =
			BindableProperty.Create("PreferredStatusBarUpdateAnimation", typeof(string), typeof(Page), "None");

		public static string GetPreferredStatusBarUpdateAnimation(BindableObject element)
		{
			return (string)element.GetValue(PreferredStatusBarUpdateAnimationProperty);
		}

		public static void SetPreferredStatusBarUpdateAnimation(BindableObject element, PageUIStatusBarAnimation value)
		{
			if (value == PageUIStatusBarAnimation.Fade)
				element.SetValue(PreferredStatusBarUpdateAnimationProperty, "Fade");
			else if (value == PageUIStatusBarAnimation.Slide)
				element.SetValue(PreferredStatusBarUpdateAnimationProperty, "Slide");
			else 
				element.SetValue(PreferredStatusBarUpdateAnimationProperty, "None");
		}

		public static string PreferredStatusBarUpdateAnimation(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetPreferredStatusBarUpdateAnimation(config.Element);
		}

		public static IPlatformElementConfiguration<iOS, FormsElement> SetPreferredStatusBarUpdateAnimation(this IPlatformElementConfiguration<iOS, FormsElement> config, PageUIStatusBarAnimation value)
		{
			SetPreferredStatusBarUpdateAnimation(config.Element, value);
			return config;
		}
	}
}
