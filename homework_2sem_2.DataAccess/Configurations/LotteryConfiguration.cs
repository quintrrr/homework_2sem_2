using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homework_2sem_2.DataAccess.Configurations 
{
    public class LotteryConfiguration : IEntityTypeConfiguration<Lottery>
    {
        public void Configure(EntityTypeBuilder<Lottery> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .HasMany(l => l.Tickets)
                .WithOne(t => t.Lottery)
                .HasForeignKey(t => t.LotteryId);

            builder
                .OwnsOne(l => l.NumberRange);
        }
    }
}
