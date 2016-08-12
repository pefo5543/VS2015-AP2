using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class WeaponPhoto
    {
            [Key,ForeignKey("Weapon")]
            public int WeaponId { get; private set; }
            public byte[] Image { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}