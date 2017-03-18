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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Content.Res;

namespace XamarinTeek
{
    [Activity(Label = "BrandOptionActivity", Theme ="@style/MyTheme")]
    public class BrandOptionActivity : ActionBarActivity
    {
        private ActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private ArrayAdapter mLeftAdapter;
        private List<String> mLeftDataSet;

        private ListView brandListView;
        private List<Brand> allBrand;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BrandOption);

            brandListView = FindViewById<ListView>(Resource.Id.brandListView);

            //new data service and get all brand here..

            //put list in view
            brandListView.Adapter = new BrandListAdapter(this, allBrand);

            //fast scroll if has long list data
            brandListView.FastScrollEnabled = true;

            //Create side menu bar
            SupportToolbar mToolbar = (SupportToolbar) FindViewById(Resource.Id.my_toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            SetSupportActionBar(mToolbar);

            //add item for menu
            mLeftDataSet = new List<string>();
            mLeftDataSet.Add("Change Brand");
            mLeftDataSet.Add("Options");
            mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            mLeftDrawer.Adapter = mLeftAdapter;

            mDrawerToggle = new ActionBarDrawerToggle(
                this,
                mDrawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer);

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }
    }
}