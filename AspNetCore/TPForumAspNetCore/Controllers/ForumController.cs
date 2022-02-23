using Microsoft.AspNetCore.Mvc;
using System;
using TPForumAspNetCore.DAO;
using TPForumAspNetCore.Models;

namespace TPForumAspNetCore.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            TopicDAO topicDAO = new TopicDAO();
            return View(topicDAO.GetAll());
        }

        public IActionResult FormTopic(int? id)
        {
            TopicDAO topicDAO = new TopicDAO();
            if (id == null)
                return View();
            else
                return View(topicDAO.Get((int)id));
        }

        public IActionResult AddTopic([FromForm] Topic topic)
        {
            TopicDAO topicDAO = new TopicDAO();
            if (topic.Subject != "" && topic.Text != "")
            {
                UserDAO userDAO = new UserDAO();
                topic.Author = userDAO.Get(1); //Temporaire
                if (topic.Id == 0)
                {
                    topicDAO.Add(topic);
                    return RedirectToAction("DetailsTopic");
                }
                topicDAO.Update(topic);
                return RedirectToAction("DetailsTopic");
            }
            return BadRequest();
        }

        public IActionResult DetailsTopic(int id)
        {
            TopicDAO topicDAO = new TopicDAO();
            return View(topicDAO.Get(id));
        }

        public IActionResult DeleteTopic(int id)
        {
            TopicDAO topicDAO = new TopicDAO();
            topicDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
