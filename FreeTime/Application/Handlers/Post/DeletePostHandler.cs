using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Core;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, OperationResult>
    {
        private readonly ApplicationContext _context;
        private readonly IPostService _postService;

        public DeletePostHandler(ApplicationContext context, IPostService postService)
        {
            _context = context;
            _postService = postService;
        }

        public async Task<OperationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.Get(request.Id);
            if (post == null)
                return OperationResult.Failed($"blog post with requested id :{request.Id} was not found");
            _context.Entry(post).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return OperationResult.Success;
        }
    }
}
