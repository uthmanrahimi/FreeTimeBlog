using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Web.Application.Models.Entities.Maps
{
    public class TagEntityMap : IEntityMap
    {
        public TagEntityMap(ModelBuilder builder)
        {
            builder.Entity<TagEntity>(entity =>
            {
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
            });
        }
    }
}
