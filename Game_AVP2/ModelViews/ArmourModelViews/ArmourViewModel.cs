using Game_AVP2.Models.Avp2.Items;

namespace Game_AVP2.ModelViews
{
    public class ArmourViewModel : ItemViewModel
    {
        public string ArmourType { get; set; }
        public int Defense { get; set; }
        public int ExtraDefense { get; set; }

        public int ArmourId { get; set; }
    }
}