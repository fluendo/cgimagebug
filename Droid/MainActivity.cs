﻿
using Android.App;
using Android.OS;
using Android.Content.PM;

namespace CGImageBug.Droid
{
	[Activity (Label = "LongoMatch.Mobile.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			// http://forums.xamarin.com/discussion/21148/calabash-and-xamarin-forms-what-am-i-missing
			Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
				if (!string.IsNullOrWhiteSpace (e.View.StyleId)) {
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};

			LoadApplication (new App ());
		}
	}
}


