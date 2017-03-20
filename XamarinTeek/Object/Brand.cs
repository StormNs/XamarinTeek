using System;

namespace XamarinTeek
{
    public class Brand
    {
        public Brand(string name, string imageUrl)
        {
            this.name = name;
            this.imageUrl = imageUrl;
        }

        public String name { get; set; }
        public String imageUrl { get; set; }

    }
}