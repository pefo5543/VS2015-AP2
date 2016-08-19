using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items.Tables
{
    public class ArmourImage
    {
        public ArmourImage()
        {
            this.Armours = new HashSet<Armour>();
        }
        [Key]
        public int ArmourImageId { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileName { get; set; }
        public string ThumbnailLink { get; set; }

        //[Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual ICollection<Armour> Armours { get; set; }
    }
}