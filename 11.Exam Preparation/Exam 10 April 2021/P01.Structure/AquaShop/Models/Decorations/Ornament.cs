namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int ornamentComfort = 1;
        private const decimal ornamentPrice = 5.0m;

        public Ornament()
            : base(ornamentComfort, ornamentPrice) { }
    }
}
