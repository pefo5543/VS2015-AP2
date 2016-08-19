namespace Game_AVP2.ModelViews
{
    public class CharacterBaseViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description {get; set;}
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int StrengthModifier { get; set; }
        public int DefenceModifier { get; set; }
    }
}