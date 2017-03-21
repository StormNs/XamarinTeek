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

namespace XamarinTeek.Object
{
    class Account
    {
        public Account()
        {
        }

        public Account(int id, string username,string imageUrl,int point)
        {
            this.Id = id;
            this.username = username;
            this.imageUrl = imageUrl;
            this.point = point;
        }
        public int Id { get; set; }
        public String username { get; set; }
        public String imageUrl { get; set; }
        public int point { get; set; }
    }
}