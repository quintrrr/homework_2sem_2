using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_2sem_2.DataAccess.Repositories
{
    public class TicketRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTickets(IEnumerable<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                var ticketEntity = _dbContext.Tickets
                    .Include(t => t.PurchaseInfo)
                    .FirstOrDefault(t => t.Id == ticket.Id);

                if (ticketEntity == null)
                {
                    _dbContext.Tickets.Add(ticket);
                }
                else
                {
                    _dbContext.Entry(ticketEntity).CurrentValues.SetValues(ticket);
                    if (ticket.PurchaseInfo != null)
                    {
                        if (ticketEntity.PurchaseInfo == null)
                        {
                            ticketEntity.PurchaseInfo = new PurchaseInfo();
                        }
                        _dbContext.Entry(ticketEntity.PurchaseInfo)
                            .CurrentValues.SetValues(ticket.PurchaseInfo);
                    }
                }
            }
            _dbContext.SaveChanges();
        }

        public object? GetInfoById(Guid id)
        {
            return _dbContext.Tickets
                .Where(t => t.Id == id)
                .AsNoTracking()
                .Select(t => new
                {
                    t.Id,
                    OwnerName = t.Owner.Name,
                    LotteryName = t.Lottery.Name,
                    t.IsWinning,
                    Numbers = String.Join(",", t.Numbers),
                    PurchaseDate = t.PurchaseInfo.Date,
                    t.PurchaseInfo.PurchaseNumber,
                }).FirstOrDefault();
        }
    }

}
