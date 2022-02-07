using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using Xamarin.Essentials;

namespace ss

{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button take;
        private ImageView image;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickEvents();
        }

        private void UIReference()
        {
            take = FindViewById<Button>(Resource.Id.button);
            image = FindViewById<ImageView>(Resource.Id.imageView1);
        }

        private void UIClickEvents()
        {
            take.Click += Take_Click;
        }

        private async void Take_Click(object sender, EventArgs e)
        {
            if (Screenshot.IsCaptureSupported)
            {
                ScreenshotResult screenshot = await Screenshot.CaptureAsync();
                Stream stream = await screenshot.OpenReadAsync();
                image.SetImageBitmap(BitmapFactory.DecodeStream(stream));

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}