namespace FreeTime.Web.Application.Models.Entities
{
    public class PostTagEntity:IEntity
    {
        public PostEntity Post { get; set; }
        public int PostId { get; set; }
        public TagEntity Tag { get; set; }
        public int TagId { get; set; }

    }
}
