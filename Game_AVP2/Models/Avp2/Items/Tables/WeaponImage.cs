using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class WeaponImage
    {
        public WeaponImage()
        {
            this.Weapons = new HashSet<Weapon>();
        }
        [Key]
        public int WeaponImageId { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileName { get; set; }
        public string ThumbnailLink { get; set; }

        //[Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}