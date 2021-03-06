﻿using FreeTime.Application.Common.Interfaces;
using FreeTime.Domain.Entities;
using FreeTime.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Infrastructure.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, int>, IDataContext
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostTagEntity> PostTags { get; set; }
        public DbSet<PostCommentEntity> Comments { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IApplicationConfiguration applicationConfiguration) : base(options)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedUserAndRolesData(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Added:
                        (entity.Entity).CreatedOn = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SeedUserAndRolesData(ModelBuilder builder)
        {
            builder.Entity<Role>(entity =>
            {
                entity.HasData(
                    new Role { Id = 1, Name = _applicationConfiguration.AdminRoleName, Description = "administrator", NormalizedName = "admin" },
                    new Role { Id = 2, Name = _applicationConfiguration.UserRoleName, Description = "members", NormalizedName = "USER" }
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
