namespace TPForumAspNetCore.Models
{
    public class User
    {
        private int id;
        private bool isAdmin;
        private string nickName;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string password;
        private int nbPosts;

        public int Id { get => id; set => id = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public int NbPosts { get => nbPosts; set => nbPosts = value; }
        public User()
        {

        }
        public User(string nickName, string firstName, string lastName, string email, string phone, string password)
        {
            NickName = nickName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            NbPosts = 0;
            IsAdmin = false;
        }
    }
}
