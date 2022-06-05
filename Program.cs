using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>() { 1,new RandomObject() { Name = "123" } , 3, 4, new RandomObject() { Name = "123" } };
            object[] array = new object[] { 1, list, new RandomObject() { Name = "345" } };

            foreach (var VAR in Reflection.ConstructEnumerator(array))
            {
                Console.WriteLine(VAR);
            }
            Console.WriteLine();

            foreach (var VAR in Reflection.ConstructEnumerator(array, 0))
            {
                Console.WriteLine(VAR);
            }
            Console.Read();

        }
    }
}
