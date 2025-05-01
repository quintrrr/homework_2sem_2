using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_2sem_2.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Lottery> Lotteries { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
