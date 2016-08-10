using Game_AVP2.Models.Avp2.Items;

namespace Game_AVP2.Controllers
{
    public class WeaponViewModel : ItemViewModel
    {
        public string WeaponType { get; set; }
        public int Damage { get; set; }
        public int ExtraDamage { get; set; }

        public WeaponViewModel(Item i) : base(i)
        {
        }

        public WeaponViewModel(Item i, Weapon w) : this(i)
        {
            WeaponType = w.WeaponType;
            Damage = w.Damage;
            ExtraDamage = w.ExtraDamage;
        }
    }
}