
using FreeTime.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeTime.Application.Mappings
{
    public class PostTagMap : IEntityTypeConfiguration<PostTagEntity>
    {
        public void Configure(EntityTypeBuilder<PostTagEntity> builder)
        {
            builder.ToTable("PostTags");
            builder.HasKey(e => new { e.PostId, e.TagId });
            builder.HasOne(e => e.Post).WithMany(e => e.PostTags).HasForeignKey(c => c.PostId);
            builder.HasOne(e => e.Tag).WithMany(e => e.Posts).HasForeignKey(c => c.TagId);
        }
    }
}
