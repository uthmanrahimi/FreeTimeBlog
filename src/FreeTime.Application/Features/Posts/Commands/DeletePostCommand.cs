using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Commands
{
    public class DeletePostCommand : IRequest<OperationResult>
    {
        public int Id { get; }
        public DeletePostCommand(int id)
        {
            Id = id;
        }

        public class DeletePostHandler : IRequestHandler<DeletePostCommand, OperationResult>
        {
            private readonly IDataContext _context;

            public DeletePostHandler(IDataContext context)
            {
                _context = context;
            }

            public async Task<OperationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.SingleOrDefaultAsync(x=>x.Id==request.Id);
                if (post == null)
                    return OperationResult.Failed($"blog post with requested id :{request.Id} was not found");
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync(cancellationToken);
                return OperationResult.Success;
            }
        }

    }
}
