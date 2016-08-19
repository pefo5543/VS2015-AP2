using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.ModelViews
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Rarity { get; set; }

        public int Value { get; set; }
        public string Image { get; set; }
        public int ImageId { get; set; }
    }
}