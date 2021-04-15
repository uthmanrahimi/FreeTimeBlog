using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FreeTime.Infrastructure.Context;
using System.Collections;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NUnit;
using NUnit.Framework;
using Respawn;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Application.UnitTests
{
    [SetUpFixture]
    public class TestFixture
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkPoint;

        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var services = new ServiceCollection();
            var startup = new Startup(_configuration);
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkPoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationHistory" }
            };

             EnsureDatabase();
        }

        public static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationContext>();
         //   context.Database.Migrate();
        }
        public static async Task ResetState()
        {
            await _checkPoint.Reset(_configuration.GetConnectionString("DataConnection"));
        }

        public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationContext>();
            context.Add(entity);
            await context.SaveChangesAsync();

        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            return await mediator.Send(request);
        }
    }
}
