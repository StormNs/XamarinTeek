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
    class Activities
    {
        public Activities()
        {
        }

        public Activities(string name,int eventId,DateTime startTime,DateTime endTime,int prizePoint, string imageUrl)
        {
            this.name = name;
            this.eventId = eventId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.prizePoint = prizePoint;
            this.imageUrl = imageUrl;
        }

        public String name { get; set; }
        public String imageUrl { get; set; }
        public int eventId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int prizePoint { get; set; }
    }
}