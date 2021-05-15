using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITMO.JSON.MyParser
{
    public static class MyJsonParser
    {
        public static Expando JsonParser(string namefile)
        {
            string fulltext = ReadFile(namefile);
            string[] elementGlobal = Parse(fulltext);


            dynamic obj = new Expando()
            {
                { "foo", "hello" },
                { "bar", 42 },
                { "baz", new object() }
            };
            int value = obj.bar;
            return obj;
        }


        private static string ReadFile(string namefile)
        {
            string fulltext;

            using (var file = new StreamReader(namefile))
            {
                fulltext = file.ReadToEnd();
            }
            return fulltext;
        }

        private static string[] Parse(string fulltext)
        {
            deleteSpace(fulltext);
            string[] separator = { "[", "]" };
            string[] elementGlobal = fulltext.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return elementGlobal;
        }
        private static string deleteSpace(string fulltext)
        {
            fulltext = fulltext.Replace("\n", "");
            fulltext = fulltext.Replace("\r", "");
            return fulltext;
        }


    }
}
