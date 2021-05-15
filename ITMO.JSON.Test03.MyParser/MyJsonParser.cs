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
            List<string> elementGlobal = new List<string>();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            while (elementGlobal.Count >0)
            {
                AddDictionary(elementGlobal[0], ref dictionary);
                elementGlobal.RemoveAt(0);
            }
           

            List<dynamic> listDynamic = new List<dynamic>();
            return listDynamic;
        }
        private static void AddDictionary(string elementGlobal, ref Dictionary<string, object> dictionary)
        {
            string temp = "";          
            temp = elementGlobal.Remove(0, elementGlobal.IndexOf("\""));                   
            string key = temp.Substring(0, temp.IndexOf("\""));
            temp = temp.Remove(0, temp.IndexOf(":"));
            if (IfEndElement(temp))
            {
                temp = temp.Substring(0, temp.IndexOf("}"));
            }

            Object val = temp;



            dictionary.Add(key, val);
        }




        public static Expando JsonParserElement(string elementGlobal)
        {                    
          
            dynamic obj = new Expando()
            {
                { "foo", "hello" },
                { "bar", 42 },
                { "baz", new object() }
            };        
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

        private static List<string> Parse(string fulltext)
        {
            fulltext = DeleteSpace(fulltext);
            string[] separator = { ","};
            string[] elementGlobal = fulltext.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          
            List<string> list = new List<string>();
            foreach (var i in elementGlobal)
                list.Add(i);

            return list;
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
