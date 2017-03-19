
using Android.Graphics;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Net;

namespace XamarinTeek
{
    public class Ultility
    {
        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        //public static ArrayAdapter GetItemForActionBar()
        //{
        //     List<String> mLeftDataSet = new List<String>();
        //      ArrayAdapter mLeftAdapter;
        //mLeftDataSet.Add("Change Brand");
        //    mLeftDataSet.Add("Options");
        //    mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.ActivityListItem, mLeftDataSet);
        //}
    }

}