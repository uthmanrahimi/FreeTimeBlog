using FluentValidation;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Comments.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get;private set; }
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCommandHanlder : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IDataContext _context;

        public DeleteCommandHanlder(IDataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(request.Id);
            if (entity == null)
                throw new NullReferenceException(nameof(DeleteCommandHanlder));
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

    public class DeleteCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).GreaterThan(0).WithMessage("Comment is not valid");
        }
    }
}
