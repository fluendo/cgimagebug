using System;
using Xamarin.Forms;

namespace CGImageBug
{
	public class App : Application
	{

		CGImageBug.Image img1, img2, img3;

		public App ()
		{
			img1 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();
			//img2 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();
			//img3 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();

			Button b = new Button {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Bug",
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
			Console.WriteLine ("Serializing");
			img1.Serialize ();
			//img2.Serialize ();
			//img3.Serialize ();
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
