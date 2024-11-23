using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TheCollectorApp.Models
{
    // Testar Data Annotations för hantera validering
    // Data Annotation Validators with the Entity Framework

    [Table("Users")]
    public class User
    {
        [Key] // Markerars som pirmärnyckel i databasen
        [Display(Name = "ID")] // Visas i UI
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ökar automatiskt
        public int UserId { get; set; }

        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Förnamn måste anges")]
        [StringLength(30)] // Längde på texten
        [Column("FirstName")] // Kolumnnamn i databas
        public required string FirstName { get; set; } // "required" gör så att egenskapen måste ha ett värde

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(30)]
        [Column("SecondName")]
        public required string SecondName { get; set; }

        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Användarnamn måste anges")]
        [StringLength(50)]
        [Column("UserName")]
        public required string UserName { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Lösenord måste anges")]
        [StringLength(30)]
        [Column("Password")]
        public required string Password { get; set; }

        [Display(Name = "E-post")]
        [Required(ErrorMessage = "E-post måste anges")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-postadressen måste innehålla @")]
        [StringLength(30)]
        [Column("Email")]
        public required string Email { get; set; }

        [Column("RegistrationDate")]
        public DateTime RegistrationDate { get; set; } // Ska inte ändras

        [Column("IsLoggedIn")]
        public bool IsLoggedIn { get; set; }

        // Navigation egenskap         
        public virtual ICollection<Collection> Collections { get; set; }

        // Entity Framwork (EF) behöver en tom konstruktor för att skapa ett objekt 
        public User()
        {
            Collections = new List<Collection>();
            IsLoggedIn = false;
            RegistrationDate = DateTime.Now;
        }

        public User(string firstName, string secondName, string userName, string password, string email) : this() // Anropar tomma konskturon User
        {
            FirstName = firstName;
            SecondName = secondName;
            UserName = userName;
            Password = password;
            Email = email;
        }
        /*
                public static void AddUser(User user)
                {
                    users.Add(user);
                }


                // Returnerar en användare baserat på namn
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

                // Returnerar en användare baserat på ID
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

                // Uppdaterar egenskaper för en användare baserat på namn 
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
                            break; // Avslutar sökningen om användaren hittas
                        }
                    }
                }

                // Uppdaterar egenskaper för en användare baserat på ID
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
                            break;
                        }
                    }
                }

                // Tar bort en användare baserat på namn
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

                // Tar bort en användare baserat på ID
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

                // Returnerar alla registrerade användare
                public static List<User> GetAllUsers()
                {
                    return users;
                }
        */
        // Loggar in användare med användarnamn och lösenord. Returnerar True om inloggning lyckas, annars False
        public bool LoginUser(string userName, string password)
        {
            if (UserName == userName && Password == password)
            {
                IsLoggedIn = true;
                return true;
            }
            return false;
        }

        // Loggar ut användaren
        public void LogoutUser()
        {
            IsLoggedIn = false;
        }
    }
}
