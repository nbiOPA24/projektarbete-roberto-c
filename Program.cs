using TheCollectorApp;

class Program
{
    static void Main()
    {

        //=== Testar klassen CollectionItem ===




        var item1 = new CollectionItem("Boken", "En bra bok som handlar om läsning", 199, ItemCondition.MycketBra, "Boken är lite sliten på första sidan.");
        var item2 = new CollectionItem("Filmen", "En film som handlar om en film", 99, ItemCondition.Daligt, "Film är trasig och går inte att använda. Men är ett bra minne och kan ställas i bokhyllan.");
        var item3 = new CollectionItem("Musse pig figur", "En äldre figur från Disney", 1999, ItemCondition.Utmarkt, "Figuren har varit bevarad i en glasmonter på ett museum.");

        // Lägg till samlarobjekt
        CollectionItem.AddItem(item1);
        CollectionItem.AddItem(item2);
        CollectionItem.AddItem(item3);

        Console.WriteLine("Alla objekt innan remove metoden används");
        VisaAllaObjekt();

        Console.WriteLine("Tar bort objekt");
        CollectionItem.RemoveItem(1);

        Console.WriteLine("Alla objekt efter remove metoden används");
        VisaAllaObjekt();

        static void VisaAllaObjekt()
        {
            Console.WriteLine("Alla samlarobjekt:");
            foreach (CollectionItem item in CollectionItem.GetAll())
            {
                Console.WriteLine($"ID: {item.ItemId}");
                Console.WriteLine($"Name: {item.ItemName}");
                Console.WriteLine($"Beskrivning: {item.Description}");
                Console.WriteLine($"Värde: {item.ItemValue}");
                Console.WriteLine($"Skick: {item.Condition}");
                Console.WriteLine($"Anteckningar: {item.Notes}");
                Console.WriteLine();
            }
        }

        /*
        // === Testar klassen Category ===
        Category book = new Category(101, "Böcker", "Min boksamling");
        Category film = new Category(202, "Filmer", "Min filmsamling");
        Category music = new Category(303, "Musik", "Min Musiksamling");
        Category toy = new Category(404, "Leksaker", "Min Leksaksamling");

        Category.AddCatetegory(book);
        Category.AddCatetegory(film);
        Category.AddCatetegory(music);
        Category.AddCatetegory(toy);

        Console.WriteLine("Alla Kategorier:");
        foreach (var category in Category.GetAll()) 
        {
            Console.WriteLine($"ID: {category.CategoryId}, Namn: {category.CategoryName}, Beskrivning: {category.Description}");
        }
        Console.ReadKey();



        // === Testar klassen User ===
        User user1 = new User(2001, "Anders", "Palla", "AndersTheWall", "malvakt123", "malvakt@mail.com");
        User user2 = new User(2002, "Jimmy", "Fridsson", "TeamSpirit", "team1234", "team@mail.com");

        // lägger till användare
        User.AddUser(user1);
        User.AddUser(user2);

        Console.WriteLine("Alla användare: ");
        foreach (var user in User.GetAllUsers())
        {
            Console.WriteLine($"ID: {user.UserId}");
            Console.WriteLine($"Förnamn: {user.FirstName}");
            Console.WriteLine($"Efternamn: {user.SecondName}");
            Console.WriteLine($"Användarnamn: {user.UserName}");
            Console.WriteLine($"E-post: {user.Email}");
            Console.WriteLine($"Registrerad: {user.RegistrationDate}");
            Console.WriteLine();
        }

        // Uppdatera användare med id 2002
        User.UpdateUser(2002, "Isabell", "Gillander", "Bella", "bella123", "bella@mail.com");

        Console.WriteLine("Alla användare efter uppdatering: ");
        foreach (var user in User.GetAllUsers())
        {
            Console.WriteLine($"ID: {user.UserId}");
            Console.WriteLine($"Förnamn: {user.FirstName}");
            Console.WriteLine($"Efternamn: {user.SecondName}");
            Console.WriteLine($"Användarnamn: {user.UserName}");
            Console.WriteLine($"E-post: {user.Email}");
            Console.WriteLine($"Registrerad: {user.RegistrationDate}");
            Console.WriteLine();
        }

        Console.WriteLine("Testar inloggning för Anders");
        //Jämför användarnamn och lösenord 
        bool loginSuccess = user1.LoginUser("AndersTheWall", "malvakt123");
        // Visar att användaren (Anders) har lyckats logga in
        Console.WriteLine($"Lyckad inloggning! Välkommen, isInlogged är {loginSuccess}.");
        Console.WriteLine($"Användaren är inloggad: {user1.IsInlogged}");
        Console.WriteLine();

        Console.WriteLine("Testar utloggning");
        user1.LogoutUser();
        Console.WriteLine($"Lyckad utloggning! Hej då, isInlogged är {user1.IsInlogged}");
        Console.WriteLine("Användare är utloggad");
        Console.WriteLine();

        // Ta bort användare
        User.RemoveUser(2001);
        Console.WriteLine();

        Console.WriteLine("Alla användare efter borttagning: ");
        foreach (var user in User.GetAllUsers())
        {
            Console.WriteLine($"ID: {user.UserId}");
            Console.WriteLine($"Förnamn: {user.FirstName}");
            Console.WriteLine($"Efternamn: {user.SecondName}");
            Console.WriteLine($"Användarnamn: {user.UserName}");
            Console.WriteLine($"E-post: {user.Email}");
            Console.WriteLine($"Registrerad: {user.RegistrationDate}");
            Console.WriteLine();
        }
                */
    }
}
