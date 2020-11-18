using System.Collections.Generic;

namespace HW7Project.Models
{
    public class ViewModel
    {
        public User UserData { get; set; }
        public IEnumerable<Repository> Repositories { get; set; }
    }
}
