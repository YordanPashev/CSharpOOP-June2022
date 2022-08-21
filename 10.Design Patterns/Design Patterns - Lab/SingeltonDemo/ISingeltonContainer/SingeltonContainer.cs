namespace SingeltonDemo
{
    public class SingeltonContainer : ISingeltonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>()
        {
            { "London", 7_123_231 },
            { "Ruse", 123_566 },
            { "Sofia", 1_725_555 },
            { "New York", 11_677_967 },
        };
        private static SingeltonContainer? instance;
        private static object lockObject = new object();

        private SingeltonContainer()
        {
            Console.WriteLine("Initializing singelton object");

            //var elements = File.ReadAllLines("capitals.txt");
            
            //for (int i = 0; i < elements.Length; i += 2)
            //{
            //    capitals.Add(elements[i], int.Parse(elements[i + 1]));
            //}
        }

        public static SingeltonContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new SingeltonContainer();
                        }
                    }
                }

                return instance;
            }
        }

        public string GetPopulation(string name)
        {
            var cityInfo = capitals.FirstOrDefault(c => c.Key == name);

            return $"{cityInfo.Key} -> {cityInfo.Value}";
        }
    }
}
