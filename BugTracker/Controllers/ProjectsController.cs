﻿using BugTracker.Helpers;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectHelper projectHelper = new ProjectHelper();
        private RoleHelper roleHelper = new RoleHelper();

        public ActionResult ManageProjectUsers()
        {
            return View("ManageProjectUsers");
        }

        // GET: Projects
        
        public ActionResult Index()

        {
            if (User.Identity.IsAuthenticated)
            {
                // Setting up project View Models  
                List<ProjectViewModel> prjVM = new List<ProjectViewModel>();
                var projects = db.Projects.ToList();
                foreach (var prj in projects)
                {
                    ProjectViewModel vm = new ProjectViewModel();
                    vm.Project = prj;
                    var pmId = db.Roles.FirstOrDefault(p => p.Name == "ProjectManager").Id;
                    vm.ProjectManager = db.Projects.Find(prj.Id).Users.FirstOrDefault(u => u.Roles.Any(r => r.RoleId == pmId));
                    prjVM.Add(vm);
                }


                //Setting up dashboard view model 
                var model = new DashboardViewModel();
                model.Projects = prjVM;
                model.Tickets = db.Tickets.ToList();
                model.Users = db.Users.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            //if (User.Identity.IsAuthenticated)
            //{
            //    return View(projectHelper.ListMyProjects());
            //}
            //else
            //    return RedirectToAction("Login", "Account");

        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = "Admin,Administrator")]
        public ActionResult Create()
        {
            ViewBag.ProjectManagerId = new SelectList(roleHelper.UsersInRole("ProjectManager"), "Id", "DisplayName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize (Roles = "Admin,Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,UserId")] Project project, string projectManagerId)
        {
            var pmId = User.IsInRole("ProjectManager");
            if (ModelState.IsValid)
            {
                
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles ="Admin,Administrator,ProjectManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Administrator,ProjectManager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,UserId,Created,Updated")] Project project)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Admin,Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
