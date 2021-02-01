using FreeTime.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Common.Interfaces
{
    public interface IDataContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostTagEntity> PostTags { get; set; }
        public DbSet<PostCommentEntity> Comments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
