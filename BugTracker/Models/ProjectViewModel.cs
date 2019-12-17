using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        public ApplicationUser User { get; set; }
        public string ProjectManagerId { get; set; }
        public DateTime? Updated { get; set; }

        public List<string> ProjectManagerName { get; set; }

        public ProjectViewModel()
        {
            ProjectManagerName = new List<string>();
        }

    }
}