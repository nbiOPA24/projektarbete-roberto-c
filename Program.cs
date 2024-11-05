using System;
using TheCollectorApp;

class Program
{
    static void Main()
    {
        // === Testar klassen Category ===

        Console.WriteLine("=== Alla fördefinierade kategorier (1-6)===");
        foreach (var category in Category.GetAllStandardCategories())
        {
            ShowCategoriesInfo(category);
        }

        // Skapa egna kategorier
        Console.WriteLine("=== Skapar egna kategorier (7, 8, 9) ===");

        var customCategory1 = Category.AddCustomCategory("Mynt & Numismatik", "Olika typer av mynt och sedlar: Guldmynt, Kopparmynt, Mynthäften");
        var customCategory2 = Category.AddCustomCategory("Smycken & Ädelstenar", "Olika typer av smycken och accessoarer: Klockor, Ringar, Halsband");
        var customCategory3 = Category.AddCustomCategory("Motorcyklar", "Olika typer av motorcyklar: Sportmotorcyklar, Cruisers, Touringmotorcyckel");
        Console.WriteLine();

        Console.WriteLine("=== Alla Kategorier: Fördefinierade och anpassade (1-9) ===");
        foreach (var category in Category.GetAllCategories())
        {
            ShowCategoriesInfo(category);
        }

        Console.WriteLine("=== Hämta kategorier basert på namn (Mynt) ===");
        foreach (var category in Category.GetCategoryByName("Mynt"))
        {
            ShowCategoriesInfo(category);
        }

        Console.WriteLine("=== Hämta kategori baserat på id (2) ===");
        foreach (var category in Category.GetCategoryById(2))
        {
            ShowCategoriesInfo(category);
            Console.WriteLine();
        }

        // Kategori som skall ersätta customCategory1
        Console.WriteLine("=== Uppdatera kategori (7) baserat namn ===");
        Category.UpdateCategoryByName(customCategory1.CategoryName, "Lyxklockor", "Exempel: Sportklockor, Dressklockor");

        Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori 7 ===");

        foreach (var category in Category.GetAllCategories())
        {
            ShowCategoriesInfo(category);
        }

        // Kategori som skall ersätta customCategory2
        Console.WriteLine("=== Uppdatera kategori (8) baserat ID ===");
        Category.UpdateCategoryById(customCategory2.CategoryId, "Skor", "Exempel: Vardagsskor, Träningskor, Finskor");
        Console.WriteLine();

        Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori 7");
        foreach (var category in Category.GetAllCategories())
        {
            ShowCategoriesInfo(category);
        }

        //Ta bort kategori baserat på namn
        Category.RemoveCategoryByName(customCategory2.CategoryName);

        Console.WriteLine("=== Alla Kategorier: Utan kategori 8");
        foreach (var category in Category.GetAllCategories())
        {
            ShowCategoriesInfo(category);
        }

        // Ta bort kategori baserat på ID
        Category.RemoveCategoryById(customCategory1.CategoryId);
        Console.WriteLine("=== Alla Kategorier: Utan kategori 7");
        foreach (var category in Category.GetAllCategories())
        {
            ShowCategoriesInfo(category);
        }
    }

    // Metod för att hämta info om alla kategorier
    private static void ShowCategoriesInfo(Category category)
    {
        Console.WriteLine($"ID: {category.CategoryId}");
        Console.WriteLine($"Name: {category.CategoryName}");
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

