using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Common.Models;
using FreeTime.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class PostViewedNotificationHandler : INotificationHandler<DomainEventNotification<PostViewed>>
    {
        private readonly IDataContext _context;

        public PostViewedNotificationHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task Handle(DomainEventNotification<PostViewed> notification, CancellationToken cancellationToken)
        {
            if (notification.DomainEvent.PostId == 0)
                throw new ArgumentException(nameof(notification.DomainEvent.PostId));
            var post = await _context.Posts.SingleAsync(x => x.Id == notification.DomainEvent.PostId);
            post.ViewCount++;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
