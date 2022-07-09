namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minAge;
        private int maxAge;

        public MyRangeAttribute(int minAge, int maxAge)
        {
            this.minAge = minAge;
            this.maxAge = maxAge;
        }

        public override bool IsValid(object obj)
        {
            int currAge = (int)obj;
            return currAge >= minAge && currAge <= maxAge;
        }
    }
}
