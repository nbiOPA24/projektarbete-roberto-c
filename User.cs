using System.Collections.Generic;

namespace TheCollectorApp
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsInlogged { get; set; }

        // lista med kollektioner
        public List<Collection> Collections { set; get; }
        
        // List med användare
        private static List<User> users = new List<User>();

        public User(int id, string firstName, string secondName, string userName, string password, string email)
        {
            UserId = id;
            FirstName = firstName;
            SecondName = secondName;
            UserName = userName;
            Password = password;
            Email = email;
            RegistrationDate = DateTime.Now;
            IsInlogged = false;
            Collections = new List<Collection>();
        }
    }
}