using FluentAssertions;

using FreeTime.Application.Features.Posts.Queries;
using FreeTime.Domain.Entities;

using NUnit.Framework;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeTime.Application.UnitTests.Post.Queries
{
    using static TestFixture;

    public class GetPostsQueryTests:TestBase
    {
        [Test]
        public async Task ShouldReturnAllPosts()
        {
            await AddAsync(new PostEntity
            {
                Title = "title",
                Description = "desc",
                CreatedOn = DateTime.Now,
                Slug = "slug",
                Status = Domain.Entities.Enums.PostStatus.Published,
                ViewCount = 0,
            });

            var query =new  GetAllPostsQuery(0,10);
            var result =await SendAsync(query);
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            result.Data.First().ViewCount.Should().Be(0);

        }
    }
}
