namespace FreeTime.Domain.Entities
{
    public class ProfileEntity:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string About { get; set; }
        public string StackOverflowProfile { get; set; }
        public string LinkedinProfile { get; set; }
        public string GithubProfile { get; set; }
        public string TwitterProfile { get; set; }
    }
}
