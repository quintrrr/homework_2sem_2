using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using homework_2sem_2.DataAccess.Models;

namespace homework_2sem_2
{
    public class LotteryDataset
    {
        public List<Lottery>? Lotteries { get; set; }
        public List<Participant>? Participants { get; set; }
        public List<Ticket>? Tickets { get; set; }

        public static LotteryDataset? DeserializeData(string path)
        {
            string extension = Path.GetExtension(path).ToLower();
            if (extension == ".json")
            {
                var lotteryJson = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<LotteryDataset>(lotteryJson, options);
            }
            else if (extension == ".xml")
            {
                var xmlSerializer = new XmlSerializer(typeof(LotteryDataset));
                var lotteryXml = File.OpenRead(path);
                return xmlSerializer.Deserialize(lotteryXml) as LotteryDataset;
            }
            else
            {
                throw new Exception("Неверный формат файла");
            }
        }

    }

}
