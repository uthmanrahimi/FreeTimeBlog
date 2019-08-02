using FreeTime.Web.Application.Core;
using MediatR;

namespace FreeTime.Web.Application.Commands
{
    public class UpdatePostCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
    }
}