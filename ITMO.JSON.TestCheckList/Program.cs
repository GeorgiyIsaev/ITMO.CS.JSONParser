using System;

namespace ITMO.JSON.TestCheckList
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckList.TXTParser.file_readTXT("TEMPTXT.txt");   

            Console.WriteLine("Демонстрация");
            foreach (CheckList.QuestItem item in CheckList.QuestsBox.questItems)
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}
