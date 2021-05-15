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

        public static List<dynamic> JsonParser(string namefile)
        {
            string fulltext = ReadFile(namefile);
            string[] elementGlobal = Parse(fulltext);
            List<dynamic> list = new List<dynamic>();         
            list.Add(JsonParserElement());


            return list;
        }


        public static Expando JsonParserElement()
        {
            string fulltext = ReadFile(namefile);
            string[] elementGlobal = Parse(fulltext);

         

            dynamic obj = new Expando()
            {
                { "foo", "hello" },
                { "bar", 42 },
                { "baz", new object() }
            };


            List<dynamic> list = new List<dynamic>();
            list.Add(obj);
            
        
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
            fulltext = DeleteSpace(fulltext);
            string[] separator = { ","};
            string[] elementGlobal = fulltext.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return elementGlobal;
        }
        private static string DeleteSpace(string fulltext)
        {
            fulltext = fulltext.Replace("\n", "");
            fulltext = fulltext.Replace("\r", "");
            fulltext = fulltext.Replace("   ", "");
            return fulltext;
        }

        private static void ElementPara(string element, ref string key, ref Object val)
        {



        }

        private static bool IfNewElement(string element)
        {
            if (element.Contains('{'))
            {    
                return true;
            }            
            return false;
        }
        private static bool IfEndElement(string element)
        {
            if (element.Contains('}'))
            {
                return true;
            }
            return false;
        }
        private static bool IfNewInnerElement(string element)
        {
            if (element[0] == '[')
            {
                return true;
            }
            return false;
        }
        private static bool IfEndInnerElement(string element)
        {
            if (element[element.Length -1] == ']')
            {
                return true;
            }
            return false;
        }


    }
}
