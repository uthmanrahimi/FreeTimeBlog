using FluentValidation;
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

    public class UpdatePostCommandValidator: AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(v => v.Title).NotNull().NotEmpty().WithMessage("Title is Required");
            RuleFor(r => r.Tags).NotEmpty().NotNull().WithMessage("At least one tag is required");
            RuleFor(r => r.Description).NotEmpty().WithMessage("Post Content is Required").MinimumLength(100);
            RuleFor(r => r.Tags).NotEmpty().NotNull().WithMessage("At least one tag is required");
        }
    }
}