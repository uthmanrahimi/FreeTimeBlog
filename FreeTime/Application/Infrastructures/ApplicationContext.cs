using FreeTime.Web.Application.Models.Entities;
using FreeTime.Web.Application.Models.Entities.Identity;
using FreeTime.Web.Application.Models.Entities.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Web.Application.Infrastructures
{
    public class ApplicationContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<PostEntity> Posts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new PostEntityMap(builder);

           // base.OnModelCreating();
        }

    }
}
