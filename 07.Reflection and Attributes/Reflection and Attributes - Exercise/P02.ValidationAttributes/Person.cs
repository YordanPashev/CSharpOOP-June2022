namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        [MyRequired]
        public string name { get; set; }

        [MyRange(12,90)]
        public int Age { get; set; }
    }
}
