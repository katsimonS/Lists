using System;

namespace Lists
{
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList(new[] { 1,33, 2, 0, -3, 3, 4, 5 });


            array.RemoveFirstNItems(2);
            foreach (var item in array)
            {
                Console.Write($"{item}\t");
            }
        }
    }
}
