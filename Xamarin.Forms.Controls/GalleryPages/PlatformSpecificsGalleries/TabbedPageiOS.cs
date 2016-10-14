using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms.Controls.GalleryPages.PlatformSpecificsGalleries
{
	public class TabbedPageiOS : TabbedPage
	{
		public TabbedPageiOS(ICommand restore)
		{
			Children.Add(CreatePage(restore, "Page One"));
			Children.Add(CreatePage(restore, "Page Two"));
		}

		ContentPage CreatePage(ICommand restore, string title)
		{
			var page = new ContentPage {
				Title = title
			};
			var content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(0, 20, 0, 0)
			};
			content.Children.Add(new Label
			{
				Text = "TabbedPage iOS Features",
				FontAttributes = FontAttributes.Bold,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			});

			var togglePrefersStatusBarHiddenButton = new Button
			{
				Text = "Toggle PrefersStatusBarHidden for TabbedPage"
			};
			var togglePrefersStatusBarHiddenButtonForPageButton = new Button
			{
				Text = "Toggle PrefersStatusBarHidden for Page"
			};
			var togglePreferredStatusBarUpdateAnimationButton = new Button
			{
				Text = "Toggle PreferredStatusBarUpdateAnimation"
			};

			togglePrefersStatusBarHiddenButton.Command = new Command(() =>
			{
				On<iOS>().SetPrefersStatusBarHidden(!On<iOS>().PrefersStatusBarHidden());
			});

			togglePrefersStatusBarHiddenButtonForPageButton.Command = new Command(() =>
			{
				page.On<iOS>().SetPrefersStatusBarHidden(!page.On<iOS>().PrefersStatusBarHidden());
			});

			togglePreferredStatusBarUpdateAnimationButton.Command = new Command(() =>
			{
				var animation = page.On<iOS>().PreferredStatusBarUpdateAnimation();
				if (animation == "Fade")
					page.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.Slide);
				else if (animation == "Slide")
					page.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.None);
				else
					page.On<iOS>().SetPreferredStatusBarUpdateAnimation(PlatformConfiguration.iOSSpecific.Page.PageUIStatusBarAnimation.Fade);
			});

			var restoreButton = new Button { Text = "Back To Gallery" };
			restoreButton.Clicked += (sender, args) => restore.Execute(null);
			content.Children.Add(restoreButton);
			content.Children.Add(togglePrefersStatusBarHiddenButton);
			content.Children.Add(togglePrefersStatusBarHiddenButtonForPageButton);
			content.Children.Add(togglePreferredStatusBarUpdateAnimationButton);
			content.Children.Add(new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = "Note: Setting the PrefersStatusBarHidden value on a TabbedPage applies that value to all its subpages."
			});

			page.Content = content;

			return page;
		}
	}
}
