using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace XamarinTeek
{
    public class BrandOptionsFragment : Fragment
    {
        private ListView brandListView;
        private List<Brand> allBrand;
        //private static FragmentManager dadFrag;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          


            // Create your fragment here
        }

        public static BrandOptionsFragment NewInstance()
        {
            var brandFrag = new BrandOptionsFragment { Arguments = new Bundle()};
            return brandFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            
            //base.OnCreateView(inflater, container, savedInstanceState);
            

            View view =  inflater.Inflate(Resource.Layout.BrandOptions, container, false);

            brandListView = view.FindViewById<ListView>(Resource.Id.brandListView);
            ////new data service and get all brand here..
            Brand b1 = new Brand("Passio", "http://www.vietcv.net/wp-content/uploads/2016/08/4fb04b7765e4.jpg");
            allBrand = new List<Brand>();
            allBrand.Add(b1);
            //put list in list view
            FragmentManager fragManager = FragmentManager;
            Fragment fragment = EventListFragment.NewInstance();
            brandListView.Adapter = new BrandListAdapter(this.Activity, allBrand, fragManager, fragment);

            //fast scroll if has long list data
            brandListView.FastScrollEnabled = true;

            return view;
        }
    }
}