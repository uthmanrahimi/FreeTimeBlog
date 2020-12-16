namespace FreeTime.Web.Application
{
    public interface IApplicationConfiguration
    {
        string Title { get; }
        string AdminRoleName { get; }
        string UserRoleName { get; }
        int PostsPerPage { get; }
    }
}
