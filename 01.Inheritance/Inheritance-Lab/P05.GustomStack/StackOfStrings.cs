using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
            => this.Count == 0;


        public Stack<string> AddRange(IEnumerable<string> elementsToAdd)
        {
            foreach (var element in elementsToAdd)
            {
                this.Push(element);
            }

            return this;
        }
    }
}
