using MediatR;

namespace FreeTime.Web.Application.Notifications
{
    public class PostViewed:INotification
    {
        public int PostId { get;private set; }
        public PostViewed(int postId)
        {
            PostId = postId;
        }
    }
}
