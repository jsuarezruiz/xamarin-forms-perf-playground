using System.Collections.Generic;

namespace XAMLCPerformance.Models
{
    public class Profile
    {
        public string Banner { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public List<Friend> Friends { get; set; }
    }

    public class Friend
    {
        public string Picture { get; set; }
        public string Name { get; set; }
    }
}
