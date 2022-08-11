namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int palntComfort = 5;
        private const decimal palntPrice = 10.0m;

        public Plant()
            : base(palntComfort, palntPrice) { }
    }
}
