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

        // Likt CRUD

        // Skapar användare
        public static void AddUser(User user)
        {
            users.Add(user);
        }

        // Läser användare
        public static User GetUser(int id)
        {
            foreach (User user in users)
            {
                if (user.UserId == id)
                {
                    return user;
                }
            }
            return null;
        }

        // Uppdaterar användare
        public static void UpdateUser(int id, string newFirstName, string newSecondName, string newUserName, string newPassword, string newEmail)
        {
            foreach (User user in users)
            {
                if (user.UserId == id)
                {
                    user.FirstName = newFirstName;
                    user.SecondName = newSecondName;
                    user.UserName = newUserName;
                    user.Password = newPassword;
                    user.Email = newEmail;
                }
            }
        }

        // Tar bort användare
        public static void RemoveUser(int id)
        {
            foreach (User user in users)
            {
                if (user.UserId == id)
                {
                    users.Remove(user);
                    break;
                }
            }
        }

        // Hämtar alla användare
        public static List<User> GetAllUsers()
        {
            return users;
        }

        // Användare loggar in med användarnamn och lösenord, därefter blir inloggad.  
        public bool LoginUser(string userName, string password)
        {
            if (UserName == userName && Password == password)
            {
                IsInlogged = true;
                return true;
            }
            return false;
        }

        // Användare loggar ut
        public void LogoutUser()
        {
            IsInlogged = false;
        }
    }
}