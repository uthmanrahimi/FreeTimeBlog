using MediatR;

namespace FreeTime.Web
{
    public class CreatePostCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public int WriterId { get; set; }
    }
}