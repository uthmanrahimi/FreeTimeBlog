using FreeTime.Domain.Entities;
using FreeTime.Web.Application.Flags;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Infrastructure.Mappings
{
    public class TagEntityMap : IEntityMap
    {
        public TagEntityMap(ModelBuilder builder)
        {
            builder.Entity<TagEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
            });
        }
    }
}
