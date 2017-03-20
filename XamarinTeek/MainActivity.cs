using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;


namespace XamarinTeek
{
    [Activity(Label = "XamarinTeek", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += delegate
            {
                StartActivity(typeof(MainLayoutActivity));
            };

            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

        }
        
    }
}

