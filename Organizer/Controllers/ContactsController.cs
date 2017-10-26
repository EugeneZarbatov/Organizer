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
    /// Контроллер для списка контактов (Contacts).
    /// </summary>
    public class ContactsController : Controller
    {
        private OrganizerContext db = new OrganizerContext();

        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Patronymic,BirthDate,Organization,Position")] Contact contact, List<string> phone, List<string> email, List<string> skype, List<string> other)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                
                foreach (string item in phone)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(item, null, null, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in email)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, item, null, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in skype)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, null, item, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in other)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, null, null, item, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.Where(c => c.Id == id).Include(c => c.contactInformation).FirstAsync();
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Patronymic,BirthDate,Organization,Position")] Contact contact, List<string> phone, List<string> email, List<string> skype, List<string> other)
        {
            if (ModelState.IsValid)
            {
                List<ContactInformation> contactInformations = await db.ContactInformations.Where(c => c.ContactId == contact.Id).ToListAsync();
                foreach (var item in contactInformations) {
                    db.ContactInformations.Remove(item);
                }

                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                
                foreach (string item in phone)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(item, null, null, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in email)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, item, null, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in skype)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, null, item, null, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }
                foreach (string item in other)
                {
                    if (item != null && item != "")
                    {
                        db.ContactInformations.Add(new ContactInformation(null, null, null, item, contact.Id));
                        await db.SaveChangesAsync();
                    }
                }

                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Search/
        public async Task<ActionResult> Search(int? page, string str = null)
        {
            IEnumerable<Contact> contacts = await db.Contacts.Include(c => c.contactInformation).ToListAsync();
            IEnumerable<ContactInformation> contactInformations = await db.ContactInformations.ToListAsync();

            ViewBag.str = str;

            if (!String.IsNullOrEmpty(str))
            {
                contacts = from contactInfo in contactInformations
                           join contact in contacts
                           on contactInfo.ContactId equals contact.Id
                           where (contact.FirstName ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contact.LastName ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contact.Patronymic ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contact.Organization ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contact.Position ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contact.BirthDate.ToShortDateString() ?? String.Empty).Contains(str) ||
                                 (contactInfo.PhoneNumber ?? String.Empty).Contains(str) ||
                                 (contactInfo.Email ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contactInfo.Skype ?? String.Empty).ToUpper().Contains(str.ToUpper()) ||
                                 (contactInfo.OtherInfo ?? String.Empty).ToUpper().Contains(str.ToUpper())
                           select contact;
            }

            contacts = contacts.Distinct().OrderBy(c => c.FirstName);

            int pageSize = 5;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            return PartialView(contacts.ToPagedList(pageNumber, pageSize));
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