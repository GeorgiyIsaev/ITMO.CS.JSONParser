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





            dynamic foo = new ExpandoObject().Init(
                "A".WithValue(true),
                "B".WithValue("Bar"));
        }
            
        

    }
    public static class ExpandoObject
    {
        public static KeyValuePair<string, object> WithValue(this string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }


        public static ExpandoObject Init(
            this ExpandoObject expando, params KeyValuePair<string, object>[] values)
        {
            foreach (KeyValuePair<string, object> kvp in values)
            {
                ((IDictionary<string, Object>)expando)[kvp.Key] = kvp.Value;
            }
            return expando;
        }
    }
}
