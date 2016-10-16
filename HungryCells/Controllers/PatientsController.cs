using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HungryCells.Data;
using HungryCells.Models;
using System.Collections.Generic;

namespace HungryCells.Controllers
{
    public class PatientsController : Controller
    {
        private HeartRecordContext db = new HeartRecordContext();

        // GET: Patients
        public ActionResult Index(string searchString)
        {
            var patients = from m in db.Patients
                         select m;

            if (!System.String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.LastName.Contains(searchString));
                return View(patients);
            }

            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,UR,FirstName,LastName,BirthDate,ReferralDate,ReferralSource,WaitListed,DVA,Status,ProcedureDate,Procedure,ValveType")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Status = "Referred";
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public ActionResult FollowUp(int id)
        {
            return View();
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {

            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            var statuses = GetAllStatuses();
            var procedures = GetAllProcedures();
            var valves = GetAllValves();
            patient.Statuses = GetSelectListItems(statuses);
            patient.Procedures = GetSelectListItems(procedures);
            patient.ValveTypes = GetSelectListItems(valves);
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,UR,FirstName,LastName,BirthDate,ReferralDate,ReferralSource,WaitListed,DVA,Status,ProcedureDate,Procedure,ValveType")] Patient patient)
        {
            var statuses = GetAllStatuses();
            var procedures = GetAllProcedures();
            var valves = GetAllValves();
            patient.Statuses = GetSelectListItems(statuses);
            patient.Procedures = GetSelectListItems(procedures);
            patient.ValveTypes = GetSelectListItems(valves);
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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

        // Define the available statuses
        private IEnumerable<string> GetAllStatuses()
        {
            return new List<string>
            {
                "Referred",
                "In Testing",
                "Discussed",
                "Having Procedure",
                "Not fit for Procedure",
                "Had Procedure",
            };
        }

        // Define the available procedures
        private IEnumerable<string> GetAllProcedures()
        {
            return new List<string>
            {
                "Femoral",
                "Apical",
            };
        }

        // Define the available valves
        private IEnumerable<string> GetAllValves()
        {
            return new List<string>
            {
                "CoreValve",
                "Edwards Implanted",
                "Edwards Solace",
                "LOTUS Valve",
                "PORTICO",
                "CENTERA",
            };
        }

        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the edit page to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

    }
}
