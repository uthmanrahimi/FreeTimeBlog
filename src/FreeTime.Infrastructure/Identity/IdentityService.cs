using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FreeTime.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<OperationResult> CreateUserAsync(string userName, string password)
        {
            var user = new User { UserName = userName, FirstName = userName };
            var createResult = await _userManager.CreateAsync(user, password);
            if (createResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return OperationResult.Success;
            }
            return OperationResult.Failed("Try Again");

        }

        public async Task<OperationResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return OperationResult.Success;
        }

        public async Task<OperationResult> SignInAsync(string userName, string password, bool rememberMe, bool lockOutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockOutOnFailure);
            if (result.Succeeded)
                return OperationResult.Success;
            if (result.IsLockedOut)
                return OperationResult.Failed("Account is Lock");
            return OperationResult.Failed("Try again");
        }
    }
}
