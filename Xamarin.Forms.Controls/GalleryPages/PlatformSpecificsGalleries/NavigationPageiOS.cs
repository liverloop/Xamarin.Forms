using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms.Controls.GalleryPages.PlatformSpecificsGalleries
{
	public class NavigationPageiOS : NavigationPage
	{
		public NavigationPageiOS(Page root, ICommand restore) : base(root)
		{
			BackgroundColor = Color.Pink;
			On<iOS>().EnableTranslucentNavigationBar();
			CurrentPage.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.Fade);
			root.On<iOS>().SetPrefersStatusBarHidden(true);
		}

		public static NavigationPageiOS Create(ICommand restore)
		{
			var restoreButton = new Button { Text = "Back To Gallery" };
			restoreButton.Clicked += (sender, args) => restore.Execute(null);

			var translucentToggleButton = new Button { Text = "Toggle Translucent NavBar" };
			var togglePrefersStatusBarHiddenButton = new Button
			{
				Text = "Toggle PrefersStatusBarHidden"
			};
			var togglePreferredStatusBarUpdateAnimationButton = new Button
			{
				Text = "Toggle PreferredStatusBarUpdateAnimation"
			};
			var content = new ContentPage
			{
				Title = "Navigation Page Features",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					Children = { translucentToggleButton, restoreButton, togglePrefersStatusBarHiddenButton, togglePreferredStatusBarUpdateAnimationButton}
				}
			};

			var navPage = new NavigationPageiOS(content, restore);

			togglePrefersStatusBarHiddenButton.Command = new Command(() =>
			{
				navPage.CurrentPage.On<iOS>().SetPrefersStatusBarHidden(!navPage.CurrentPage.On<iOS>().PrefersStatusBarHidden());
			});

			togglePreferredStatusBarUpdateAnimationButton.Command = new Command(() =>
			{
				var animation = navPage.On<iOS>().PreferredStatusBarUpdateAnimation();
				if (animation == "Fade")
					navPage.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.Slide);
				else if (animation == "Slide")
					navPage.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.None);
				else
					navPage.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.Fade);
			});

			return navPage;
		}
	}
}