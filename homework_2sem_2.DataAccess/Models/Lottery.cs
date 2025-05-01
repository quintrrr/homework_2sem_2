using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace homework_2sem_2.DataAccess.Models
{
    public class Lottery
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal TicketPrice { get; set; }

        public NumberRange? NumberRange { get; set; }

        public int[] WinningCombination { get; set; } = [];

        public decimal PrizeFund { get; set; }

        public DateTime DrawTime { get; set; }

        public List<Ticket> Tickets { get; set; } = [];
    }

    public class NumberRange
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public int NumbersPerTicket { get; set; }
    }
}
