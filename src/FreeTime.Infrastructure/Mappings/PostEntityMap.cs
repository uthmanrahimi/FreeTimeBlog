using FreeTime.Domain.Entities;
using FreeTime.Domain.Entities.Enums;
using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Infrastructure.Mappings
{
    public class PostEntityMap : IEntityMap
    {
        public PostEntityMap(ModelBuilder builder)
        {
            builder.Entity<PostEntity>(c =>
            {
                c.HasKey(p => p.Id);
                c.ToTable("posts");
                c.Property(p => p.Title).IsRequired();
                c.Property(p => p.Slug).IsRequired();
                c.Property(p => p.Description).IsRequired();
                c.Property(p => p.CreatedOn).IsRequired();
                c.Property(p => p.Status).IsRequired().HasDefaultValue(PostStatus.Draft);
                //c.HasOne().WithMany().HasForeignKey(p => p.WriterId).IsRequired();
                //TODO: FIX Above problem
                
            });
        }
    }
}
