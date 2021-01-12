namespace FreeTime.Web.Application.Core
{
    public class BlogSettings
    {
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public int PostsPerPage { get; set; }
        public string Postfix { get; set; }
        public bool AllowCommentsForGuests { get; set; }
    }
}
