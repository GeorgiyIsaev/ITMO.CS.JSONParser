using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ITMO.JsonParser.CheckList
{
    class Program
    {
        static void Main(string[] args)
        {
            WPF_CheckListQuests.QuestsBox.file_readTXT("TEMPTXT1.txt");
            JsonParser.WriteJSON();

            List<WPF_CheckListQuests.QuestItem> questItems 
                = new List<WPF_CheckListQuests.QuestItem>();

            JsonParser.ReadJSON(questItems);


            Console.WriteLine("Демонстрация");
            foreach (WPF_CheckListQuests.QuestItem item in questItems)
            {
                Console.WriteLine(item.Description);
           
            }     


        }
    }
}
