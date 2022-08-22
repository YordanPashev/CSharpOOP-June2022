namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Gathering Ingredients for {this.GetType().Name} Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Baking the {this.GetType().Name} Bread. (15 minutes)");
        }

        public override void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread in 12 slices!");
        }
    }
}
