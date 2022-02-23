using System;
using System.Collections.Generic;

namespace TPForumAspNetCore.Models
{
    public class Topic
    {
        private int id;
        private DateTime dateCreation;
        private User author;
        private string subject;
        private string text;
        private List<Message> messages;
        public Topic()
        {
            DateCreation = DateTime.Now;
        }
        public Topic(User author, string subject, string text)
        {
            Author = author;
            Subject = subject;
            Text = text;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public User Author { get => author; set => author = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Text { get => text; set => text = value; }
        public List<Message> Messages { get => messages; set => messages = value; }
    }
}
