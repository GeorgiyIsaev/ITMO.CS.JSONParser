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
            Dictionary<string, object> dictionary = new Dictionary<string, object>()
                                                {
                                                    {"Ali", "Ostad"}
                                                };

            dictionary.Ali

            dynamic obj = new ImpromptuDictionary()
            {
                { "foo", "hello" },
                { "bar", 42 },
                { "baz", new object() }
            };



            //dynamic foo = new ExpandoObject().Init(
            //    "A".WithValue(true),
            //    "B".WithValue("Bar"));


            //dynamic foo = new ExpandoObject().Init(
            //    "A".WithValue(true),
            //    "B".WithValue("Bar"));


        }
            
        

    }
    //public static class ExpandoObject
    //{
    //    public static KeyValuePair<string, object> WithValue(this string key, object value)
    //    {
    //        return new KeyValuePair<string, object>(key, value);
    //    }
    //}

    //public static class ExpandoObject
    //{
    //    public static ExpandoObject Init(
    //        this ExpandoObject expando, params KeyValuePair<string, object>[] values)
    //    {
            
    //        foreach (KeyValuePair<string, object> kvp in values)
    //        {
    //            ((IDictionary<string, Object>)expando)[kvp.Key] = kvp.Value;
    //        }
    //        return expando;
    //    }
    //}

    public static class ExtensionMethods
    {
        public static ExpandoObject Init(this ExpandoObject expando, dynamic obj)
        {
            var expandoDic = (IDictionary<string, object>)expando;
            foreach (System.Reflection.PropertyInfo fi in obj.GetType().GetProperties())
            {
                expandoDic[fi.Name] = fi.GetValue(obj, null);
            }
            return expando;
        }
    }
}
