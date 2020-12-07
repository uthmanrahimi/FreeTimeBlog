namespace FreeTime.Web.Application
{
    public  class ApplicationConfiguration : IApplicationConfiguration
    {
        public string Title => "";
        public string AdminRoleName => "admin";
        public string UserRoleName => "member";
    }
}
