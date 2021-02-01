using FreeTime.Domain.Common;

namespace FreeTime.Domain.Events
{
    public class PostViewed:DomainEvent
    {
        public int PostId { get; private set; }
        public PostViewed(int postId)
        {
            PostId = postId;
        }
    }
}
