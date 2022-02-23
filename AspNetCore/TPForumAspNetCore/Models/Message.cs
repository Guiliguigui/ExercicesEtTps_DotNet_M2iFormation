using System;

namespace TPForumAspNetCore.Models
{
    public class Message
    {
        private int id;
        private DateTime dateCreation;
        private User author;
        private string subject;
        private string text;
        public Message()
        {

        }
        public Message(DateTime dateCreation, User author, string subject, string text)
        {
            DateCreation = dateCreation;
            Author = author;
            Subject = subject;
            Text = text;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public User Author { get => author; set => author = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Text { get => text; set => text = value; }
    }
}
