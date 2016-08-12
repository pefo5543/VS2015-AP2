using Game_AVP2.Models.Avp2.Items;
using System.Drawing;
using System.Web;

namespace Game_AVP2.Controllers
{
    public class WeaponViewModel
    {
        public int WeaponId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string WeaponType { get; set; }

        public int Damage { get; set; }

        public int ExtraDamage { get; set; }

        public int Rarity { get; set; }

        public int Value { get; set; }
        public byte[] Image { get; set; }
        public HttpPostedFileBase Photo { get; set; }

        public void RenderWeaponPhoto(byte[] Image)
        {
            //WeaponPhoto = new WeaponPhoto();
            //WeaponPhoto.Image = Image;
        }
    }
}