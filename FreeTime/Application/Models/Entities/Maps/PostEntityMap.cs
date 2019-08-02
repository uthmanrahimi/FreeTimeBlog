using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Web.Application.Models.Entities.Maps
{
    public class PostEntityMap: IEntityMap
    {
        public PostEntityMap(ModelBuilder builder)
        {
            builder.Entity<PostEntity>(c =>
            {
                c.ToTable("posts");
                c.Property(p => p.Title).IsRequired();
                c.Property(p => p.Slug).IsRequired();
                c.Property(p => p.Description).IsRequired();
                c.Property(p => p.CreatedOn).IsRequired();
                c.Property(p => p.Status).IsRequired().HasDefaultValue(PostStatus.Draft);
                c.HasOne(p => p.Writer).WithMany().HasForeignKey(p => p.WriterId).IsRequired();
            });
        }
    }
}
