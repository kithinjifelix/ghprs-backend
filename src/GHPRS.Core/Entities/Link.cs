
namespace GHPRS.Core.Entities
{
    public class Link : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public LinkType LinkType { get; set; }
        public string Key { get; set; }
    }

    public enum LinkType
    {
        Dashboard,
        Report,
        Table,
        External
    }
}
