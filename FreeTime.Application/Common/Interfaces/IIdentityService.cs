using FreeTime.Application.Common.Models;
using System.Threading.Tasks;

namespace FreeTime.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<OperationResult> SignInAsync(string userName,string password,bool rememberMe,bool lockOutOnFailure);
        Task<OperationResult> CreateUserAsync(string userName,string password);

        Task<OperationResult> LogOutAsync();
    }
}
