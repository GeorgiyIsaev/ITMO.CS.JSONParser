using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITMO.JSON.MyParser
{
    public static class MyJsonParser02
    {
        private static string fulltext;
        private static List<string> elementGlobal;


        public static List<dynamic> JsonParser(string namefile)
        {
            fulltext = ReadFile(namefile);
            DeleteSpace();
            elementGlobal = Parse();

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            List<dynamic> listDynamic = new List<dynamic>();

            while (elementGlobal.Count > 0)
            {
                KeyValuePair<string, object> element = ElementPara();
                dictionary.Add(element.Key, element.Value);
                if ("}]" == elementGlobal[0])
                {
                    dynamic dynamicObj = new Expando();
                    foreach (var valueDictionary in dictionary)
                    {
                        dynamicObj.Add(valueDictionary.Key, valueDictionary.Value);
                    }
                    listDynamic.Add(dynamicObj);
                    dictionary = new Dictionary<string, object>();
                }
                elementGlobal.RemoveAt(0);
            }
            return listDynamic;
        }

        private static KeyValuePair<string, object> ElementPara()
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
                        KeyValuePair<string, object> element = ElementPara();
                        dictionaryInner.Add(element.Key, element.Value);
                        if ("}]" == elementGlobal[0])
                        {
                            break;
                        }
                        else if ("}" == elementGlobal[0])
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
                        break;
                    }
                }
                val = listDynamics;
                myPair = new KeyValuePair<string, object>(key, val);
                return myPair;
            }
            else if (temp.Contains("{"))
            {
                elementGlobal[0] = temp;

                Dictionary<string, object> dictionaryInner = new Dictionary<string, object>();
                while ("}" != elementGlobal[0])
                {
                    KeyValuePair<string, object> element = ElementPara();
                    dictionaryInner.Add(element.Key, element.Value);
                    if ("}" == elementGlobal[0])
                    {
                        break;
                    }
                    elementGlobal.RemoveAt(0);
                }
                dynamic dynamicObj = new Expando();
                foreach (var valueDictionary in dictionaryInner)
                {
                    dynamicObj.Add(valueDictionary.Key, valueDictionary.Value);
                }
                myPair = new KeyValuePair<string, object>(key, dynamicObj);
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




    


        private static string ReadFile(string namefile)
        {
            string fulltext;

            using (var file = new StreamReader(namefile))
            {
                fulltext = file.ReadToEnd();
            }
            return fulltext;
        }

        private static List<string> Parse()
        {
            string[] separator = { "," };
            string[] elementGlobal = fulltext.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>();
            string tempAdd="";
            foreach (var i in elementGlobal)
            {
                //if (i[i.Length - 1] != '}')
                //{
                //    tempAdd += i;
                    list.Add(i);
                //    tempAdd = "";
                //}
                //else
                //{
                //    tempAdd += i;
                //}
                
                
            }
               

            return list;
        }

        private static string DeleteSpace()
        {
            fulltext = fulltext.Replace("\n", "");
            fulltext = fulltext.Replace("\r", "");
            fulltext = fulltext.Replace("   ", "");
            return fulltext;
        }
    }
}
