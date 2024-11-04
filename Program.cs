using System;
using TheCollectorApp;

class Program
{
    static void Main()
    {

        // === Testar klassen Category ===

        Console.WriteLine("Alla standard kategorier");
        foreach (var category in Category.GetStandardCategory())
        {
            Console.WriteLine($"ID: {category.CategoryId}");
            Console.WriteLine($"Namn: {category.CategoryName}");
            Console.WriteLine($"Beskrivning: {category.Description}");
            Console.WriteLine($"Typ: {category.Type}");
            Console.WriteLine();
        }

        // Skapa egna kategorier
        var customCategory1 = Category.AddCustomCatetegory("Mynt & Numismatik", "Olika typer av mynt och sedlar: Guldmynt, Kopparmynt, Mynthäften");
        var customCategory2 = Category.AddCustomCatetegory("Smycken & Ädelstenar", "Olika typer av smycken och accessoarer: Klockor, Ringar, Halsband");


        Console.WriteLine("=== Alla Kategorier: Standard och dem man skapat själv");
        foreach (var category in Category.GetAllCategories())
        {
            Console.WriteLine($"ID: {category.CategoryId}");
            Console.WriteLine($"Namn: {category.CategoryName}");
            Console.WriteLine($"Beskrivning: {category.Description}");
            Console.WriteLine($"Typ: {category.Type}");
            Console.WriteLine();
        }

        // Kategori som skall ersätta customCategory1
        Category.UpdateCategory(customCategory1.CategoryId, "Lyxklockor", "Exempel: Rolex, Omega");

        Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori 7");
        foreach (var category in Category.GetAllCategories())
        {
            Console.WriteLine($"ID: {category.CategoryId}");
            Console.WriteLine($"Namn: {category.CategoryName}");
            Console.WriteLine($"Beskrivning: {category.Description}");
            Console.WriteLine($"Typ: {category.Type}");
            Console.WriteLine();
        }

        //Ta bort kategori customCategory2
        Category.RemoveCategory(customCategory2.CategoryId);

        Console.WriteLine("=== Alla Kategorier: Utan kategori 8");
        foreach (var category in Category.GetAllCategories())
        {
            Console.WriteLine($"ID: {category.CategoryId}");
            Console.WriteLine($"Namn: {category.CategoryName}");
            Console.WriteLine($"Beskrivning: {category.Description}");
            Console.WriteLine($"Typ: {category.Type}");
            Console.WriteLine();
        }

        /*
        // === Testar klassen User ===

        User user1 = new User("Anders", "Palla", "AndersTheWall", "malvakt123", "malvakt@mail.com");
        User user2 = new User("Jimmy", "Fridsson", "TeamSpirit", "team1234", "team@mail.com");

        // lägger till användare
        User.AddUser(user1);
        User.AddUser(user2);

        Console.WriteLine("=== Alla användare === ");
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

        // Uppdatera användare med id 2
        User.UpdateUser(2, "Isabell", "Gillander", "Bella", "bella123", "bella@mail.com");

        Console.WriteLine("=== Alla användare efter uppdatering ===");
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

        Console.WriteLine("=== Testar inloggning för Anders ===");
        //Jämför användarnamn och lösenord 
        bool loginSuccess = user1.LoginUser("AndersTheWall", "malvakt123");
        // Visar att användaren (Anders) har lyckats logga in
        Console.WriteLine($"Lyckad inloggning! Välkommen, isInlogged är {loginSuccess}.");
        Console.WriteLine($"Användaren är inloggad: {user1.IsInlogged}");
        Console.WriteLine();

        Console.WriteLine("=== Testar utloggning ===");
        user1.LogoutUser();
        Console.WriteLine($"Lyckad utloggning! Hej då, isInlogged är {user1.IsInlogged}");
        Console.WriteLine("Användare är utloggad");
        Console.WriteLine();

        // Ta bort användare
        User.RemoveUser(1);
        Console.WriteLine();

        Console.WriteLine("=== Alla användare efter borttagning ===");
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

        /*
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
*/
    }
}
