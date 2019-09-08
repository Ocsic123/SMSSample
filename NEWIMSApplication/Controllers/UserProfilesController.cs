using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEWIMSApplication.Models;

namespace NEWIMSApplication.Controllers
{
    public class UserProfilesController : Controller
    {
        private SMSEntities db = new SMSEntities();

        // GET: UserProfiles
        //[Route("Mvctest")]
        public ActionResult Index()
        {
            //var a = db.GetAllUsers();
            return View(db.UserProfiles.ToList());
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,IsActive")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,IsActive")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userProfile);
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
        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<DataItem> data { get; set; }
        }

        public class DataItem
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string DoB { get; set; }
        }

        public ActionResult AjaxGetJsonData()
        {

            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = 1;
            dataTableData.recordsTotal = 5;
            int recordsFiltered = 0;
            //dataTableData.data = FilterData(ref recordsFiltered, start, length, search, sortColumn, sortDirection);
            //dataTableData.recordsFiltered = recordsFiltered;


            DataItem customer1 = new DataItem()
            {
                Name = "1",
                Age = "Sourabh",
                DoB = "50000"
            };
            DataItem customer2 = new DataItem()
            {
                Name = "2",
                Age = "Shaili",
                DoB = "60000"
            };
            DataItem customer3 = new DataItem()
            {
                Name = "3",
                Age = "Saloni",
                DoB = "55000"
            };
            dataTableData.data = new List<DataItem>();
            dataTableData.data.Add(customer1);  // Here Add Method is used to add the item to the list
            dataTableData.data.Add(customer2);

            //adding one more customer wheather capacity is 2 only  
            dataTableData.data.Add(customer3);






            //dataTableData.data = new List<DataItem> { Name = "Anjan", Age = "20", DoB = "09/12/2019" };

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListView()
        {

            return View();
        }
    }
}
