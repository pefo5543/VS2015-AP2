using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items.Tables
{
    public class ArmourImage : TableImageBase
    {
        public ArmourImage()
        {
            this.Armours = new HashSet<Armour>();
        }
        [Key]
        public int ArmourImageId { get; set; }

        public virtual ICollection<Armour> Armours { get; set; }
    }
}