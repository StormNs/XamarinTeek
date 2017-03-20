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
    class Events
    {
        public Events()
        {
        }

        public Events(string name, string description, DateTime startDate, DateTime endDate, int brandId, int entryPoint, string imageUrl, int type)
        {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.brandId = brandId;
            this.entryPoint = entryPoint;
            this.imageUrl = imageUrl;
            this.type = type;
        }

        public String name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int brandId { get; set; }
        public int entryPoint { get; set; }
        public String imageUrl { get; set; }
        public int type { get; set; }
    }
}