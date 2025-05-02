using System.Text.Json.Serialization;

namespace homework_2sem_2.DataAccess.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public bool IsWinning { get; set; }

        public int[] Numbers { get; set; } = [];

        public PurchaseInfo? PurchaseInfo { get; set; }

        [JsonIgnore]
        public Participant? Owner { get; set; }

        [JsonIgnore]
        public Lottery? Lottery { get; set; }

        public Guid LotteryId { get; set; }

        public Guid OwnerId { get; set; }
    }

    public class PurchaseInfo
    {
        public DateTime Date { get; set; }

        public Guid PurchaseNumber { get; set; }
    }
}
