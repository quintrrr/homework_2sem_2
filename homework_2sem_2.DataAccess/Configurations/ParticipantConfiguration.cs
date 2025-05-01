using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homework_2sem_2.DataAccess.Configurations 
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Owner)
                .HasForeignKey(t => t.OwnerId);


            builder
                .OwnsOne(p => p.ContactInfo);
        }
    }
}
