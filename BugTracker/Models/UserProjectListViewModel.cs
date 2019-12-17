using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Models
{
    public class UserProjectListViewModel
    {
        public string Name { get; set; }
        public List<string> ProjectNames { get; set; }
        

        public UserProjectListViewModel()
        {
            ProjectNames = new List<string>();
        }
    }

    public class ManageProjectViewModel
    {
        public Project Project { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        public List<ApplicationUser> Developers { get; set; }
        public List<ApplicationUser> Submitters { get; set; }
        public SelectList ProjectManagers { get; set; }
        public MultiSelectList MSDevs { get; set; }
        public MultiSelectList MSSubs { get; set; }

        
    }
}