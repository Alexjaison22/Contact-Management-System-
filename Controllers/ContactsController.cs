using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContactManagementSystem_V2.Models;

namespace ContactManagementSystem_V2.Controllers
{
    public class ContactsController : Controller
    {
        private static List<Contact> contacts = new List<Contact>();

        public IActionResult Index()
        {
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = contacts.Count + 1;
                contacts.Add(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        public IActionResult Edit(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact UpdatedContact)
        {
            if (ModelState.IsValid)
            {
                var contact = contacts.Find(c => c.Id == UpdatedContact.Id);
                if (contact != null)
                {
                    contact.Name = UpdatedContact.Name;
                    contact.Email = UpdatedContact.Email;
                    contact.Phone = UpdatedContact.Phone;
                    return RedirectToAction("Index");

                }
                return NotFound();
            }
            return View(UpdatedContact);
        }
        public IActionResult Delete(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                return RedirectToAction("Index");
            }
            return NotFound();
        }


    }
}

