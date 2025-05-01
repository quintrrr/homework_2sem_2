using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homework_2sem_2.DataAccess.Configurations 
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(t => t.Lottery)
                .WithMany(l => l.Tickets)
                .HasForeignKey(t => t.LotteryId);

            builder
                .HasOne(t => t.Owner)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.OwnerId);

            builder
                .OwnsOne(t => t.PurchaseInfo);
        }
    }
}
