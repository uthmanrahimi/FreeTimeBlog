using AutoMapper;
using FluentValidation;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Comments.Commands
{
    public class AddCommentCommand : IRequest
    {
        public string Email { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int PostId { get; set; }


        public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;

            public AddCommentCommandHandler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = _mapper.Map<PostCommentEntity>(request);
                await _dataContext.Comments.AddAsync(comment);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return Unit.Task.Result;
            }
        }

        public class AddCommentCommandValidation : AbstractValidator<AddCommentCommand>
        {
            public AddCommentCommandValidation()
            {
                RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email Address is not correct")
                    .NotEmpty().NotNull().WithMessage("Email Address is required");
                RuleFor(x => x.PostId).NotEqual(0).WithMessage("Post not found");
                RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Content is required");
                RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Name is required");
            }
        }
    }
}
