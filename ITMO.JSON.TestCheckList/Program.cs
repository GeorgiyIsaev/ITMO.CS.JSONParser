using System;
using System.Collections.Generic;

namespace ITMO.JSON.TestCheckList
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckList.TXTParser.file_readTXT("TEMPTXT.txt");
            //Console.WriteLine("Демонстрация");
            //foreach (CheckList.QuestItem item in CheckList.QuestsBox.questItems)
            //{
            //    Console.WriteLine(item.ToString());

            //}

            //Тест JSON
            CheckList.JsonParser.WriteJSON();




            List<CheckList.QuestItem> questItems
                = new List<CheckList.QuestItem>();
            CheckList.JsonParser.ReadJSON(ref questItems);

            Console.WriteLine("\n\nДемонстрация");
            foreach (CheckList.QuestItem item in questItems)
            {
                Console.WriteLine(item.ToString());

            }


        }
    }
}
