using System.Collections.Generic;

namespace TheCollectorApp
{
    public class User
    {
        private static int nextId = 1;

        public int UserId { get; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; } // Är private för att öka säkerhet
        public string Email { get; set; }
        public DateTime RegistrationDate { get; }
        public bool IsInlogged { get; set; }

        // lista med kollektioner
        public List<Collection> Collections { get; set; }

        // Lista med användare
        private static List<User> users = new List<User>();

        public User(string firstName, string secondName, string userName, string password, string email)
        {
            UserId = nextId++;
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

        public static void AddUser(User user)
        {
            users.Add(user);
        }


        public static User? GetUser(int id)
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
                    break; //Avslutas om användaren hittas 
                }
            }
        }

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