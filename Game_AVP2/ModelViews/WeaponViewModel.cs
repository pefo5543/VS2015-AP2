using Game_AVP2.Models.Avp2.Items;
using System;
using System.Drawing;
using System.Reflection;
using System.Web;

namespace Game_AVP2.ModelViews
{
    public class WeaponViewModel : ItemViewModel
    {
        public WeaponViewModel()
        {

        }

        public int WeaponId { get; set; }

        public string WeaponType { get; set; }

        public int Damage { get; set; }

        public int ExtraDamage { get; set; }
    }
}