using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Web.Application.Models.Entities.Maps
{
    public class PostTagMap : IEntityMap
    {
        public PostTagMap(ModelBuilder builder)
        {
            builder.Entity<PostTagEntity>(entity =>
            {
                entity.ToTable("PostTags");
                entity.HasKey(e => new { e.PostId, e.TagId });
                entity.HasOne(e => e.Post).WithMany(e => e.PostTags).HasForeignKey(c => c.PostId);
                entity.HasOne(e => e.Tag).WithMany(e => e.Posts).HasForeignKey(c => c.TagId);
            });
        }
    }
}
