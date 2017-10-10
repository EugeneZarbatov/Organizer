using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Organizer.Models;
using PagedList;

namespace Organizer.Controllers
{
    /// <summary>
    /// Контроллер для ежедневника (Notes).
    /// </summary>
    public class HomeController : Controller
    {
        private OrganizerContext db = new OrganizerContext();

        // GET: Home
        public async Task<ActionResult> Index(int? page, string type = "Все", string duration = "Список", string beginDateTime = null, string endDateTime = null)
        {
            IEnumerable<Note> notes = await db.Notes.ToListAsync();

            ViewBag.NotesType = type;
            ViewBag.Duration = duration;
            ViewBag.endDateTime = endDateTime;
            ViewBag.beginDateTime = beginDateTime;

            if (!String.IsNullOrEmpty(type) && !type.Equals("Все"))
            {
                notes = notes.Where(n => n.Type.Contains(type));
            }
            if (beginDateTime != null && endDateTime != null && beginDateTime != "" && endDateTime != "")
            {
                notes = notes.Where(n => (n.BeginDateTime > DateTime.Parse(beginDateTime) && n.BeginDateTime < DateTime.Parse(endDateTime)));
            }
            if (!String.IsNullOrEmpty(duration) && !duration.Equals("Список"))
            {
                switch (duration)
                {
                    case "День":
                        notes = notes.Where(n => n.BeginDateTime.ToShortDateString().Equals(DateTime.Now.Date.ToShortDateString()));
                        break;
                    case "Неделя":
                        DateTime monday = DateTime.Now.Date;
                        if (monday.DayOfWeek != DayOfWeek.Monday)
                        {
                            while (monday.DayOfWeek != DayOfWeek.Monday)
                            {
                                monday = monday.AddDays(-1);
                            }
                        }
                        DateTime sunday = DateTime.Now.Date;
                        if (sunday.DayOfWeek != DayOfWeek.Sunday)
                        {
                            while (sunday.DayOfWeek != DayOfWeek.Sunday)
                            {
                                sunday = sunday.AddDays(1);
                            }
                        }

                        notes = notes.Where(n => n.BeginDateTime.Date >= monday && n.BeginDateTime.Date <= sunday);
                        break;
                    case "Месяц":
                        notes = notes.Where(n => n.BeginDateTime.ToString("MM.yyyy").Equals(DateTime.Now.ToString("MM.yyyy")));
                        break;
                }
            }

            notes = notes.OrderByDescending(n => n.BeginDateTime);

            int pageSize = 6;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            return View(notes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,Subject,BeginDateTime,EndDateTime,Place,State")] Note note)
        {
            if (note.BeginDateTime < DateTime.Now)
            {
                ModelState.AddModelError("BeginDateTime", "Дата должна быть больше текущей");
            }
            if (note.EndDateTime < DateTime.Now)
            {
                ModelState.AddModelError("EndDateTime", "Дата должна быть больше текущей");
            }
            if (note.EndDateTime <= note.BeginDateTime)
            {
                ModelState.AddModelError("BeginDateTime", "Дата начала должна быть меньше даты конца");
            }

            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,Subject,BeginDateTime,EndDateTime,Place,State")] Note note)
        {
            if (note.EndDateTime <= note.BeginDateTime)
            {
                ModelState.AddModelError("BeginDateTime", "Дата начала должна быть меньше даты конца");
            }

            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // POST: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            db.Notes.Remove(note);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Помечает событие (запись ежедневника) как выполненное.
        // GET: Home/Done/5
        public async Task<ActionResult> Done(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }

            db.Entry(note).State = EntityState.Modified;
            note.State = true;
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { page });
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