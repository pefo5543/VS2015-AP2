using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class WeaponImage : TableImageBase
    {
        public WeaponImage()
        {
            this.Weapons = new HashSet<Weapon>();
        }
        [Key]
        public int WeaponImageId { get; set; }

        //[Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}