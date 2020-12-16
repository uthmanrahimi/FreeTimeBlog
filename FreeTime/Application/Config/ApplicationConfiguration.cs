using FreeTime.Web.Application.Core;
using Microsoft.Extensions.Options;

namespace FreeTime.Web.Application
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IOptions<BlogSettings> _blogSettings;

        public ApplicationConfiguration(IOptions<BlogSettings> blogSettings)
        {
            _blogSettings = blogSettings;
        }
        public string Title => _blogSettings.Value.Title;
        public string AdminRoleName => "admin";
        public string UserRoleName => "member";
        public int PostsPerPage => _blogSettings.Value.PostsPerPage;
    }
}
