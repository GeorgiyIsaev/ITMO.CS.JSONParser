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
            fulltext = DeleteSpace(fulltext);
            List<string> elementGlobal = Parse(fulltext);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            List<dynamic> listDynamic = new List<dynamic>();
          
            while (elementGlobal.Count > 0)
            {              
                KeyValuePair<string, object> element = ElementPara(elementGlobal);                
                if (dictionary.ContainsKey(element.Key))
                {
                    dynamic dynamicObj = new Expando();
                    foreach (var valueDictionary in dictionary)
                    {
                        dynamicObj.Add(valueDictionary.Key, valueDictionary.Value);
                    }
                    listDynamic.Add(dynamicObj);
                    Console.WriteLine(dynamicObj.ToString());
                    dictionary = new Dictionary<string, object>();
                }
                dictionary.Add(element.Key, element.Value);
                if(elementGlobal.Count > 0)
                    elementGlobal.RemoveAt(0);
            }
            foreach (var val in dictionary)
            {
                Console.WriteLine(val.Key + " - " + val.Value);
            }            
            return listDynamic;
        }
        private static KeyValuePair<string, object> ElementPara(List<string> elementGlobal)
        {
            string temp = "";
            Object val;
            KeyValuePair<string, object> myPair;


            temp = elementGlobal[0].Remove(0, elementGlobal[0].IndexOf("\"") + 1);
            string key = temp.Substring(0, temp.IndexOf("\""));
            temp = temp.Remove(0, temp.IndexOf(":") + 2);
            if (temp.Contains('['))
            {
                elementGlobal[0] = temp;
                List<dynamic> listDynamics = new List<dynamic>();
                while ("}]" != elementGlobal[0])
                {
                    Dictionary<string, object> dictionaryInner = new Dictionary<string, object>();
                    while ("}" != elementGlobal[0])
                    {                                             
                        KeyValuePair<string, object> element = ElementPara(elementGlobal);
                        dictionaryInner.Add(element.Key, element.Value);
                        if ("}]" == elementGlobal[0])
                        {                           
                            break;
                        }
                        else if("}" == elementGlobal[0])
                        {
                            elementGlobal.RemoveAt(0);
                            break;
                        }
                        elementGlobal.RemoveAt(0);
                    } 
                    dynamic dynamicObj = new Expando();
                    foreach (var valueDictionary in dictionaryInner)
                    {
                        dynamicObj.Add(valueDictionary.Key, valueDictionary.Value);
                    }
                    listDynamics.Add(dynamicObj);
                    if ("}]" == elementGlobal[0])
                    {
                        elementGlobal.RemoveAt(0);
                        break;
                    }
                }                
                val = listDynamics;
                myPair = new KeyValuePair<string, object>(key, val);
                return myPair;
            }
            else if (temp.Contains("}]"))
            {
                temp = temp.Substring(0, temp.IndexOf("}"));
                elementGlobal[0] = "}]";
            }
            else if (temp.Contains("} ]"))
            {
                temp = temp.Substring(0, temp.IndexOf("}"));
                elementGlobal[0] = "}]";
            }
            else if (temp.Contains('}'))
            {
                temp = temp.Substring(0, temp.IndexOf("}"));
                elementGlobal[0] = "}";
            }
            if (temp.Contains('\"'))
            {
                val = temp.Substring(1, temp.LastIndexOf("\"") - 1); ;
            }
            else if (temp == "true") val = true;
            else if (temp == "false") val = false;            
            else
            {
                val = (object)temp;
            }
            myPair = new KeyValuePair<string, object>(key, val);
            return myPair;
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
    }
}
