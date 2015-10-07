using System;
using Xamarin.Forms;

namespace CGImageBug
{
	public class App : Application
	{

		public App ()
		{
			Button b = new Button {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Press to go to the next page",
			};
			StackLayout layout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { b },
			};

			ContentPage page = new ContentPage {
				Content = layout,
			};
			MainPage = new NavigationPage (page);
			b.Clicked += B_Clicked;
		}

		void B_Clicked (object sender, EventArgs e)
		{
			Application.Current.MainPage.Navigation.PushAsync (
				new NewPage ()
			);
		}

		protected override void OnStart ()
		{

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
