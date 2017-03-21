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
using System.Net;
using Newtonsoft.Json;
using System.IO;
using XamarinTeek.Object;

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
            //base.OnCreateView(inflater, container, savedInstanceState);
            
            View view =  inflater.Inflate(Resource.Layout.BrandOptions, container, false);
            brandListView = view.FindViewById<ListView>(Resource.Id.brandListView);

            string url = Ultility.SERVER_URL + "/Brand/Brand/getAllBrands";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //using GET - request.Headers.Add ("Authorization","Authorizaation value");
            request.ContentType = "application/json";
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            Stream rebut = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            string info = readStream.ReadToEnd();
             allBrand = JsonConvert.DeserializeObject<List<Brand>>(info);
            
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