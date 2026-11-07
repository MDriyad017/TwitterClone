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
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.TweetId).IsRequired();

            // Foreign Key Relationships
            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Tweet)
                   .WithMany()
                   .HasForeignKey(b => b.TweetId);
        }
    }
}
