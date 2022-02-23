using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPForumAspNetCore.DAO;
using TPForumAspNetCore.Models;

namespace TPForumAspNetCore.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserDAO userDAO = new UserDAO();
            return View(userDAO.GetAll());
        }

        public IActionResult FormUser(int? id)
        {
            UserDAO userDAO = new UserDAO();
            if (id == null)
                return View();
            else
                return View(userDAO.Get((int)id));
        }

        public IActionResult AddUser([FromForm] User user)
        {
            UserDAO userDAO = new UserDAO();
            if (user.NickName != "" && user.FirstName != "" && user.LastName != "" && user.Email != "" && user.Phone != "" && user.Password != "")
            {
                if (user.Id == 0)
                {
                    userDAO.Add(user);
                    return RedirectToAction("DetailsUser");
                }
                userDAO.Update(user);
                return RedirectToAction("DetailsUser");
            }
            return BadRequest();
        }

        public IActionResult DetailsUser(int id)
        {
            UserDAO userDAO = new UserDAO();
            return View(userDAO.Get(id));
        }

        public IActionResult DeleteUser(int id)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
