using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Core;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers.Post
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, OperationResult>
    {
        private readonly ApplicationContext _context;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public UpdatePostHandler(ApplicationContext context, IPostService postService, IMapper mapper)
        {
            _context = context;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.Get(request.Id);

            if (post == null)
                return OperationResult.Failed("blog post with requested id was not found");

            post = _mapper.Map(request, post);
            await _context.SaveChangesAsync();
            return OperationResult.Success;
        }
    }
}
