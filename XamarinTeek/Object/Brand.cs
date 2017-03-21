using System;

namespace XamarinTeek
{
    public class Brand
    {
        public Brand()
        {
        }

        public Brand(int id, string name, string imageUrl)
        {
            this.Id = id;
            this.name = name;
            this.imageUrl = imageUrl;
        }

        public int Id { get; set; }
        public String name { get; set; }
        public String imageUrl { get; set; }

    }
}