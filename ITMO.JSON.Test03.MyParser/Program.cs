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

            //MyTestExpando();
        }
        static void MyTestExpando()
        {
            dynamic obj = new Expando()
            {
                { "clovo", "hello" },
                { "chislo", 42 },
                { "obect", new object() }
            };
            int value = obj.chislo;
            obj.chislo = 22;
            Console.WriteLine(value);
            Console.WriteLine(obj.clovo + " " + obj.chislo);        
            obj.Add("ifelse", true);
            if(obj.ifelse)
                Console.WriteLine("obj.ifelse = " + obj.ifelse);        
        }
    }   
}
