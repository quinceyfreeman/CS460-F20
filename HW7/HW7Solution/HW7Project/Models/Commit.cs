using System;

namespace HW7Project.Models
{
    public class Commit
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public DateTime WhenCommitted { get; set; }
        public string CommitMessage { get; set; }
        public string HtmlURL { get; set; }
    }
}
