using System;
using Xamarin.Forms;

namespace CGImageBug
{
	public class NewPage: ContentPage
	{
		CGImageBug.Image img1, img2, img3;

		public NewPage ()
		{
			img1 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();
			img2 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();
			img3 = new CGImageBug.Image ("longomatch_dark_bg_png").Clone ();

			Button b = new Button {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Press me several times to reproduce the bug",
			};
			StackLayout layout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { b },
			};

			Content = layout;
			b.Clicked += B_Clicked;
		}

		void B_Clicked (object sender, EventArgs e)
		{
			Console.WriteLine ("Serializing");
			img1.Serialize ();
			img2.Serialize ();
			img3.Serialize ();
		}
	}
}

