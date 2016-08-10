using Game_AVP2.Models.Avp2.Items;

namespace Game_AVP2.Controllers
{
    public class ArmourViewModel : ItemViewModel
    {
        public string ArmourType { get; set; }
        public int Defense { get; set; }
        public int ExtraDefense { get; set; }

        public ArmourViewModel(Item i) : base(i)
        {
        }

        public ArmourViewModel(Item i, Armour a) : this(i)
        {
            ArmourType = a.ArmourType;
            Defense = a.Defense;
            ExtraDefense = a.ExtraDefense;
        }
    }
}