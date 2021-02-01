using FreeTime.Application.Common.Interfaces;
using FreeTime.Web.Application.Core;
using Microsoft.Extensions.Options;

namespace FreeTime.Infrastructure
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly BlogSettings _blogSettings;

        public ApplicationConfiguration(IOptions<BlogSettings> blogSettings)
        {
            _blogSettings = blogSettings.Value;
        }
        public string Title => _blogSettings.Title;
        public string OwnerName => _blogSettings.OwnerName;
        public string Postfix => _blogSettings.Postfix;
        public string AdminRoleName => "admin";
        public string UserRoleName => "member";
        public int PostsPerPage => _blogSettings.PostsPerPage;
    }
}
