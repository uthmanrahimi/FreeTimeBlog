using FreeTime.Application.Common.Models;
using FreeTime.Domain.Entities.Enums;
using MediatR;

namespace FreeTime.Application.Features.Posts.Commands
{
    public class UpdatePostCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public PostStatus Status { get; set; }
    }
}