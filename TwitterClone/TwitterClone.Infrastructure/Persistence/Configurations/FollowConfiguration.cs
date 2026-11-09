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
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FollowerId).IsRequired();
            builder.Property(f => f.FollowingId).IsRequired();

            // Foreign Key Relationships with User table
            builder.HasOne(f => f.Follower)
                   .WithMany()
                   .HasForeignKey(f => f.FollowerId);

            builder.HasOne(f => f.Following)
                   .WithMany()
                   .HasForeignKey(f => f.FollowingId);
        }
    }
}
