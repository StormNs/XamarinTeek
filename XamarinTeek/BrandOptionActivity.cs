using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportToolbar =  Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;

namespace XamarinTeek
{
    [Activity(Label = "BrandOptionActivity")]
    public class BrandOptionActivity : ActionBarActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BrandOption);
            SupportToolbar mToolbar = (SupportToolbar) FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mToolbar);
        }
    }
}