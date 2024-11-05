namespace TheCollectorApp
{
    public class User
    {
        private static int nextId = 1;
        // Lista som lagrar alla användare
        private static List<User> users = new List<User>();

        public int UserId { get; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; } // Private för säkerhet
        public string Email { get; set; }
        public DateTime RegistrationDate { get; } // Ska inte ändras
        public bool IsInlogged { get; set; }

        // lista med användarens samlingar
        public List<Collection> Collections { get; set; }

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

        // CRUD metoder

        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static List<User> GetUserByName(string name)
        {
            var userName = new List<User>();
            foreach (User user in users)
            {
                if (user.FirstName.Contains(name))
                {
                    userName.Add(user);
                }
            }
            return userName;
        }

        public static List<User> GetUserById(int id)
        {
            var userId = new List<User>();
            foreach (User user in users)
            {
                if (user.UserId == id)
                {
                    userId.Add(user);
                }
            }
            return userId;
        }

        public static void UpdateUserByName(string name, string newFirstName, string newSecondName, string newUserName, string newPassword, string newEmail)
        {
            foreach (User user in users)
            {
                if (user.FirstName == name)
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

        public static void UpdateUserById(int id, string newFirstName, string newSecondName, string newUserName, string newPassword, string newEmail)
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

        public static void RemoveUserByName(string name)
        {
            foreach (User user in users)
            {
                if (user.FirstName == name)
                {
                    users.Remove(user);
                    break;
                }
            }
        }

        public static void RemoveUserById(int id)
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

        // Hämtar alla registrerade användare
        public static List<User> GetAllUsers()
        {
            return users;
        }

        // Loggar in användare med användarnamn och lösenord  
        public bool LoginUser(string userName, string password)
        {
            if (UserName == userName && Password == password)
            {
                IsInlogged = true;
                return true;
            }
            return false;
        }

        // Loggar ut användare
        public void LogoutUser()
        {
            IsInlogged = false;
        }
    }
}
