using FreeTime.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeTime.Infrastructure.Context
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(IDataContext context)
        {
            if (!context.Profile.Any())
            {
                context.Profile.Add(new Domain.Entities.ProfileEntity
                {
                    About = "",
                    JobTitle = "",
                    Name = "",
                    GithubProfile = "",
                    LinkedinProfile = "",
                    StackOverflowProfile = "",
                    TwitterProfile = ""
                });
                context.SaveChangesAsync(new System.Threading.CancellationToken()).Wait();
            }
        }
    }
}
