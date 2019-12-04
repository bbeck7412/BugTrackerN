using BugTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTracker.Helpers
{
    public class ProjectHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper roleHelper = new RoleHelper();


        public List<Project> ListMyProjects()
        {
            var myProjects = new List<Project>();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var projects = db.Projects;

            var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            switch (myRole)
            {
                case "Admin":
                case "Administrator":
                    myProjects.AddRange(db.Projects);
                    break;

                case
                    "ProjectManager":
                    myProjects.AddRange(db.Projects.Where(p => p.ProjectManagerId == userId));
                    break;

                case
                    "Developer":
                case
                    "Submitter":
                    myProjects.AddRange(db.Projects.Where(p => p.Users.Select(uid => uid.Id).Contains(userId)));
                    break;
            }
            return myProjects;
        }

        //public List<Ticket> ListMyTickets()
        //{
        //    var myTickets = new List<Ticket>();
        //    var userId = HttpContext.Current.User.Identity.GetUserId();
        //    var user = db.Users.Find(userId);

        //    //Step 1: Determine my role
        //    var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
        //    switch (myRole)
        //    {
        //        case "Admin":
        //        case "Administrator":
        //            myTickets.AddRange(db.Tickets);
        //            break;

        //        case
        //        "ProjectManager":
        //            myTickets.AddRange(user.Projects.SelectMany(p => p.Tickets));
        //            break;

        //        case
        //        "Developer":
        //            myTickets.AddRange(db.Tickets.Where(t => t.DeveloperId == userId));
        //            break;

        //        case
        //        "Submitter":
        //            myTickets.AddRange(db.Tickets.Where(t => t.SubmitterId == userId));
        //            break;

        //    }


        //    return myTickets;
        //}

        public bool IsUserOnProject(string userId, int projectId)
        {
            var project = db.Projects.Find(projectId);
            var flag = project.Users.Any(m => m.Id == userId);
            return (flag);
        }

        public ICollection<Project> ListUserProjects(string userId)
        {
            ApplicationUser user = db.Users.Find(userId);

            var projects = user.Projects.ToList();
            return (projects);
        }

        public void AddUserToProject(string userId, int projectId)
        {
            if (!IsUserOnProject(userId, projectId))
            {
                Project proj = db.Projects.Find(projectId);
                var newUser = db.Users.Find(userId);

                proj.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void AddProjectManagerToProject(string userId, int projectId)
        {
            Project proj = db.Projects.Find(projectId);
            if (db.Users.Any(u => u.Id == userId) && proj != null)
            {
                proj.ProjectManagerId = userId;
                db.SaveChanges();
            }
        }

        public void RemoveUserFromProject(string userId, int projectId)
        {
            if (IsUserOnProject(userId, projectId))
            {
                Project proj = db.Projects.Find(projectId);
                var delUser = db.Users.Find(userId);

                proj.Users.Remove(delUser);
                db.Entry(proj).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public ICollection<ApplicationUser> UsersOnProject(int projectId)
        {
            return db.Projects.Find(projectId).Users;
        }
        public ICollection<ApplicationUser> UsersNotOnProject(int projectId)
        {
            return db.Users.Where(m => m.Projects.All(p => p.Id != projectId)).ToList();
        }
    }
}
