namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int palntComfort = 5;
        private const decimal palntPrice = 10;

        public Plant()
            : base(palntComfort, palntPrice) { }
    }
}
