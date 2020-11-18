using System;

namespace HW7Project.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string HtmlURL { get; set; }
        public string FullName { get; set; }
        public string OwnerAvatarURL { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
