using FreeTime.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Comments.Commands
{
    public class UpdateCommentStatusCommand : IRequest
    {
        public int CommentId { get; private set; }
        public bool Status { get; private set; }
        public UpdateCommentStatusCommand(int commentId, bool status)
        {
            CommentId = commentId;
            Status = status;
        }

        public class UpdateCommentStatusCommandHandler : IRequestHandler<UpdateCommentStatusCommand>
        {
            private readonly IDataContext _dataContext;

            public UpdateCommentStatusCommandHandler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<Unit> Handle(UpdateCommentStatusCommand request, CancellationToken cancellationToken)
            {
                var comment = _dataContext.Comments.FirstOrDefault(c => c.Id == request.CommentId);
                comment.IsApproved = request.Status;
                await _dataContext.SaveChangesAsync(cancellationToken);
                return Unit.Task.Result;
            }
        }

    }
}
