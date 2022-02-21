using Annuaire.DAO;
using Annuaire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Annuaire.Controllers
{
    public class AnnuaireController : Controller
    {
        ContactDAO contactDAO = new ContactDAO();

        public IActionResult Index()
        {
            return View(contactDAO.GetAll());
        }

        public IActionResult DetailsContact(int id)
        {
            return View(contactDAO.Get(id));
        }

        public IActionResult FormContact()
        {
            return View();
        }

        public IActionResult SubmitContact(string FirstName, string LastName, string Phone)
        {
            Contact contact = new Contact(FirstName, LastName, Phone);
            contactDAO.Save(contact);
            return View(contact);
        }

        public IActionResult FormUpdateContact(int id)
        {
            return View(contactDAO.Get(id));
        }

        public IActionResult SubmitUpdateContact(int Id, string FirstName, string LastName, string Phone)
        {
            Contact contact = new Contact(FirstName, LastName, Phone) { Id = Id };
            if (contactDAO.Update(contact))
                return View(contact);
            else
            {
                return NotFound();
            }
        }

        public IActionResult DeleteContact(int id)
        {
            return View(contactDAO.Get(id));
        }

        public IActionResult ConfirmDeleteContact(int id)
        {
            contactDAO.Delete(id);
            return View();
        }
    }
}
