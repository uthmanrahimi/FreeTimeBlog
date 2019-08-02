using FreeTime.Web.Application.Flags;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Models.Entities;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Services.Interfaces
{
    public interface IPostService : IService
    {
        Task<PostEntity> Get(int id);
        Task<int> TotalCount(PostStatus status);
    }
}
