﻿
using Android.Graphics;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Net;

namespace XamarinTeek
{
    public class Ultility
    {
        public static string SERVER_URL = "http://10.0.2.2:63096";

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

       
    }

}