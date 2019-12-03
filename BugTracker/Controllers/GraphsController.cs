using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class GraphsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Graphs
        public JsonResult DonutPriority3()
        {
            var myData = new List<MorrisDonutData>();
            MorrisDonutData data = null;
            foreach(var priority in db.TicketPriorities.ToList())
            {
                data = new MorrisDonutData();
                data.label = priority.Name;
                data.value = db.Tickets.Where(t => t.TicketPriority.Name == priority.Name).Count();
                myData.Add(data);
            }
            return Json(myData);
        }

        public JsonResult DonutStatus4()
        {
            var myData = new List<MorrisDonutData>();
            MorrisDonutData data = null;
            foreach(var status in db.TicketStatus.ToList())
            {
                data = new MorrisDonutData();
                data.label = status.Name;
                data.value = db.Tickets.Where(t => t.TicketStatus.Name == status.Name).Count();
                myData.Add(data);
            }
            return Json(myData);
        }

        public JsonResult DonutType5()
        {
            var myData = new List<MorrisDonutData>();
            MorrisDonutData data = null;
            foreach(var type in db.TicketTypes.ToList())
            {
                data = new MorrisDonutData();
                data.label = type.Name;
                data.value = db.Tickets.Where(t => t.TicketType.Name == type.Name).Count();
                myData.Add(data);
            }
            return Json(myData);
        }
    }
}