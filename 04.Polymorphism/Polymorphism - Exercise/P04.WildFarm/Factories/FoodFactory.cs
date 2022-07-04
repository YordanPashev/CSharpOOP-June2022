using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static Food CreateFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int qunatity = int.Parse(foodInfo[1]);
            Food food = null;

            if (type == "Vegetable")
            {
                food = new Vegetable(qunatity);
            }

            else if (type == "Fruit")
            {
                food = new Fruit(qunatity);
            }

            else if (type == "Meat")
            {
                food = new Meat(qunatity);
            }

            else if (type == "Seeds")
            {
                food = new Seeds(qunatity);
            }

            return food;
        }
    }
}
