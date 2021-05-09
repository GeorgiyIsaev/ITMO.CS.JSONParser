using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace CheckList
{
    public static class JsonParser
    {
      

        public static void ReadJSON(ref List<QuestItem> questItems)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Если равно true устанавливаются дополнительные пробелы и переносы (для красоты)
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //Вот эта строка Вам поможет с кодировкой
            }; 
            using (FileStream fs = new FileStream("test.json", FileMode.Open))
            {         
                questItems = JsonSerializer.DeserializeAsync<List<QuestItem>>(fs, options).Result;
                //Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                int a=0;
            }
        }
        static public void WriteJSON()
        {
            //string json = JsonSerializer.Serialize(WPF_CheckListQuests.QuestsBox.questItems);
            //Console.WriteLine(json);
            Console.WriteLine("Запись в JSON");
            /*Запишем коллекцию эл-тов в документ JSON*/
            /*Условием зададим проверку о существовании файла*/
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Если равно true устанавливаются дополнительные пробелы и переносы (для красоты)
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //Вот эта строка Вам поможет с кодировкой
            };
            if (File.Exists("test.json"))
            {
                using (FileStream file = new FileStream("test.json", FileMode.Truncate))
                {
                    JsonSerializer.SerializeAsync(file, QuestsBox.questItems, options);
                }
            }
            else
            {
                using (FileStream file = new FileStream("test.json", FileMode.Create))
                {
                    JsonSerializer.SerializeAsync(file, QuestsBox.questItems, options);
                }
                //string json = Encoding.UTF8.GetString(client.DownloadData(url));
            }

        }


    }
}
