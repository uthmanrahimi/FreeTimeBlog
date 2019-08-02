using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Models.Entities;
using FreeTime.Web.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationContext _context;

        public PostService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PostEntity> Get(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(p=>p.Id==id);
        }

        public  async Task<int> TotalCount(PostStatus status)
        {
            return await _context.Posts.CountAsync(p=>p.Status==status);
        }
    }
}
