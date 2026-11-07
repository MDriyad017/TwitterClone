using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.UserId).IsRequired();
            builder.Property(l => l.TweetId).IsRequired();

            // Foreign Key Relationships
            builder.HasOne(l => l.User)
                   .WithMany()
                   .HasForeignKey(l => l.UserId);

            builder.HasOne(l => l.Tweet)
                   .WithMany()
                   .HasForeignKey(l => l.TweetId);
        }
    }
}
