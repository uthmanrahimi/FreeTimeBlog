using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class PostViewedNotificationHandler : INotificationHandler<PostViewed>
    {
        private readonly ApplicationContext _context;

        public PostViewedNotificationHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(PostViewed notification, CancellationToken cancellationToken)
        {
            if (notification.PostId == 0)
                throw new ArgumentException(nameof(notification.PostId));
            var post = await _context.Posts.SingleAsync(x => x.Id == notification.PostId);
            post.ViewCount++;
            await _context.SaveChangesAsync();
        }
    }
}
