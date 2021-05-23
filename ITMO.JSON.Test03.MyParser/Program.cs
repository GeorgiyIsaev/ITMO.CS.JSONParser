using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;


namespace ITMO.JSON.MyParser
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<dynamic> list = MyJsonParser.JsonParser("test.json");

            int i = 0;
            Console.WriteLine($"Мои элементы:");
            foreach (var val in list)
            {
                Console.WriteLine($"Елемент {i++}");
                Console.WriteLine($"{val}");
            }
            Console.ReadKey();

        }
        static void MyTest()
        {
            dynamic obj = new Expando()
            {
                { "foo", "hello" },
                { "bar", 42 },
                { "baz", new object() }
            };
            int value = obj.bar;
            Console.WriteLine(value);
        }

    }   
}
