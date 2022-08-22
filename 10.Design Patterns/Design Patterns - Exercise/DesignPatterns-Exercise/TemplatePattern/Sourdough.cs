namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Gathering Ingredients for {this.GetType().Name} Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Baking the {this.GetType().Name} Bread. (20 minutes)");
        }
    }
}
