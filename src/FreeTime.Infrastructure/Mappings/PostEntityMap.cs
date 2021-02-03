using FreeTime.Domain.Entities;
using FreeTime.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeTime.Infrastructure.Mappings
{
    public class PostEntityMap :IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
           builder.HasKey(p => p.Id);
           builder.ToTable("Posts");
           builder.Property(p => p.Title).IsRequired();
           builder.Property(p => p.Slug).IsRequired();
           builder.Property(p => p.Description).IsRequired();
           builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(PostStatus.Draft);
            //c.HasOne().WithMany().HasForeignKey(p => p.WriterId).IsRequired();
            //TODO: FIX Above problem
        }
    }
}
