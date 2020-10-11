﻿using FreeTime.Web.Application.Models.Entities;
using FreeTime.Web.Application.Models.Entities.Identity;
using FreeTime.Web.Application.Models.Entities.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

            builder.Entity<Role>(entity =>
            {
                entity.HasData(
                    new Role { Id = 1, Name = ApplicationConfiguration.AdminRoleName, Description = "administrator", NormalizedName = "admin" },
                    new Role { Id = 2, Name = ApplicationConfiguration.UserRoleName, Description = "members", NormalizedName = "USER" }
                    );
            });

            var hasher = new PasswordHasher<User>();
            var user = new User() { Id = 1, Email = "admin@admin.com", UserName = "admin@admin.com", NormalizedUserName = "admin@admin.com".ToUpper(), NormalizedEmail = "admin@admin.com", SecurityStamp = Guid.NewGuid().ToString() };
            user.PasswordHash = hasher.HashPassword(null, "admin@qwe");
            builder.Entity<User>(entity =>
            {
                entity.HasData(user);
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasData(
                    new UserRole { UserId = 1, RoleId = 1 },
                    new UserRole { UserId = 1, RoleId = 2 }
                    );
            });
        }

    }
}
