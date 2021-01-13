using FreeTime.Domain.Entities;
using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Infrastructure.Mappings
{
    public class PostCommentMap : IEntityMap
    {
        public PostCommentMap(ModelBuilder builder)
        {
            builder.Entity<PostCommentEntity>(entity =>
            {
                entity.ToTable("Comments");
                entity.Property(c => c.Content).IsRequired();
                entity.Property(c => c.CreatedOn).HasDefaultValueSql("GETDate()");
                entity.Property(c => c.Email).IsRequired().HasMaxLength(50);
                entity.Property(c => c.AuthorName).IsRequired().HasMaxLength(50);
                entity.HasOne(c => c.Post).WithMany(c => c.Comments).HasForeignKey(c => c.PostId);
            });
        }
    }
}
