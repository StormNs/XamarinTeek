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

namespace XamarinTeek
{
    class Event
    {
        public Event(int id, string name, string imageUrl, string description)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Description = description;
        }

        public int Id { get; }
        public String Name { get; set; }
        public String ImageUrl { get; set; }
        public String Description { get; set; }
    }
}