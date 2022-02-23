namespace TPForumAspNetCore.Models
{
    public class Administrator : User
    {
        public Administrator() : base()
        {
                
        }
        public Administrator(string nickName, string firstName, string lastName, string email, string phone, string password) : base(nickName, firstName, lastName, email, phone, password)
        {
            IsAdmin = true;
        }
    }
}
