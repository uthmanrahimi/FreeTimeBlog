using FreeTime.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeTime.Infrastructure.Mappings
{
    public class PostCommentMap :IEntityTypeConfiguration<PostCommentEntity>
    {
        public void Configure(EntityTypeBuilder<PostCommentEntity> builder)
        {
            builder.ToTable("Comments");
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedOn);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.AuthorName).IsRequired().HasMaxLength(50);
            builder.HasOne(c => c.Post).WithMany(c => c.Comments).HasForeignKey(c => c.PostId);
        }
    }
}
