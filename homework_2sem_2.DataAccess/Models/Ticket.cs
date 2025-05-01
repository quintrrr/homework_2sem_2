namespace homework_2sem_2.DataAccess.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public bool IsWinning { get; set; }

        public int[] Numbers { get; set; } = [];

        public PurchaseInfo? PurchaseInfo { get; set; }

        public decimal PrizeFund { get; set; }

        public Participant? Owner { get; set; }

        public Lottery? Lottery { get; set; }

        public Guid LotteryId { get; set; }

        public Guid OwnerId { get; set; }
    }

    public class PurchaseInfo
    {
        public DateTime Date { get; set; }

        public Guid purchaseNumber { get; set; }
    }
}
