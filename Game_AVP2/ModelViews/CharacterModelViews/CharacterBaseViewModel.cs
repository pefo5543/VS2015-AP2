namespace Game_AVP2.ModelViews
{
    public class CharacterBaseViewModel : BaseViewModel
    {
        public CharacterBaseViewModel()
        {
            this.Attribute = new AttributeViewModel();
        }
        public string Name { get; set; }
        public string Description {get; set;}
        public string Background { get; set; }
        public AttributeViewModel Attribute { get; set; }
        public int EquippedWeaponId { get; set; }
        public int EquippedArmourId { get; set; }
        public int AbilityID { get; set; }
        public int ImageId { get; set; }
    }
}