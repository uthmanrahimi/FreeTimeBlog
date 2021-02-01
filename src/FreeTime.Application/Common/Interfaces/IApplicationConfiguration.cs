namespace FreeTime.Application.Common.Interfaces
{
    public interface IApplicationConfiguration
    {
        string Title { get; }
        string OwnerName { get; }
        string AdminRoleName { get; }
        string UserRoleName { get; }
        int PostsPerPage { get; }
        string Postfix { get; }
    }
}
