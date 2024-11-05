using System;
using TheCollectorApp;

class Program
{
    static void Main()
    {

        // === Testar klassen User ===

        User user1 = new User("Anders", "Palla", "AndersTheWall", "malvakt123", "malvakt@mail.com");
        User user2 = new User("Jimmy", "Fridsson", "TeamSpirit", "team1234", "team@mail.com");
        User user3 = new User("Karin", "Sten", "Stenen", "sten1234", "sten@mail.com");

        // lägger till användare
        User.AddUser(user1);
        User.AddUser(user2);
        User.AddUser(user3);

        Console.WriteLine("=== Alla användare === ");
        foreach (var user in User.GetAllUsers())
        {
            ShowAllUserInfo(user);
        }

        Console.WriteLine("=== Hämtar användare basert på namn (Anders) ===");
        foreach (var user in User.GetUserByName("Anders"))
        {
            ShowAllUserInfo(user);
        }
        Console.WriteLine();

        Console.WriteLine("=== Hämtar användare baserat på ID (2) ===");
        foreach (var user in User.GetUserById(2))
        {
            ShowAllUserInfo(user);
        }
        Console.WriteLine();

        Console.WriteLine("=== Användare uppdaterad baserat på namn (Anders) ===");
        User.UpdateUserByName("Anders", "Isabell", "Gillander", "Bella", "bella123", "bella@mail.com");
        foreach (var user in User.GetAllUsers())
        {
            ShowAllUserInfo(user);
        }

        Console.WriteLine("=== Användare uppdaterad baserat på ID (2) ===");
        User.UpdateUserById(2, "Marie", "Gren", "Grenen", "grenen123", "gren@mail.com");
        foreach (var user in User.GetAllUsers())
        {
            ShowAllUserInfo(user);
        }

        Console.WriteLine("=== Testar inloggning för Isabell ===");
        //Jämför användarnamn och lösenord 
        bool loginSuccess = user1.LoginUser("Bella", "bella123");
        // Visar att användaren (Anders) har lyckats logga in
        Console.WriteLine($"Lyckad inloggning! Välkommen, isInlogged är {loginSuccess}.");
        Console.WriteLine($"Användaren är inloggad: {user1.IsInlogged}");
        Console.WriteLine();

        Console.WriteLine("=== Testar utloggning ===");
        user1.LogoutUser();
        Console.WriteLine($"Lyckad utloggning! Hej då, isInlogged är {user1.IsInlogged}");
        Console.WriteLine("Användare är utloggad");
        Console.WriteLine();

        User.RemoveUserByName("Isabell");
        Console.WriteLine("=== Borttagning baserat på namn (Isabell) ===");
        foreach (var user in User.GetAllUsers())
        {
            ShowAllUserInfo(user);
        }
        Console.WriteLine();

        User.RemoveUserById(2);
        Console.WriteLine("=== Borttagning baserat på ID ===");
        foreach (var user in User.GetAllUsers())
        {
            ShowAllUserInfo(user);
        }
        Console.WriteLine();
    }

    // Metod för att hämta info om alla användare
    private static void ShowAllUserInfo(User user)
    {
        Console.WriteLine($"ID: {user.UserId}");
        Console.WriteLine($"Förnamn: {user.FirstName}");
        Console.WriteLine($"Efternamn: {user.SecondName}");
        Console.WriteLine($"Användarnamn: {user.UserName}");
        Console.WriteLine($"E-post: {user.Email}");
        Console.WriteLine($"Registrerad: {user.RegistrationDate}");
        Console.WriteLine();
    }
}

/*
//=== Testar klassen CollectionItem ===

var item1 = new CollectionItem("En man som heter Ove", "En svensk roman om en surmulen äldre man som sakta dras in i grannarnas liv och blir påverkad av deras värme och vänlighet. ", 199, ItemCondition.MycketBra, "Boken är lite sliten på den första sidan.");
var item2 = new CollectionItem("The Matrix", "Filmen är en sci-fi-film där en hacker upptäcker att verkligheten är en simulering styrd av maskiner, och han måste kämpa för mänsklighetens frihet.", 99, ItemCondition.Dåligt, "Film är trasig och går inte att använda. Men är ett bra minne och kan ställas i bokhyllan.");
var item3 = new CollectionItem("Musse Pigg-figur: Limited Edition-figurer:", "Speciella samlarobjekt som producerats i begränsad upplaga, ofta av företag som Disney Store eller Hallmark.", 19999, ItemCondition.Utmärkt, "Figuren har varit bevarad i en glasmonter på ett museum.");

// Lägg till samlarobjekt
CollectionItem.AddItem(item1);
CollectionItem.AddItem(item2);
CollectionItem.AddItem(item3);

Console.WriteLine("=== Alla samlarobjekt ===");
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}
Console.WriteLine();

Console.WriteLine("=== Hämtar samlarobjekt basert på namn (The Matrix) ===");
foreach (var item in CollectionItem.GetItemByName("The Matrix"))
{
    ShowAllItemInfo(item);
}
Console.WriteLine();

Console.WriteLine("=== Hämtar samlarobjekt baserat på ID (1) ===");
foreach (var item in CollectionItem.GetItemById(1))
{
    ShowAllItemInfo(item);
}
Console.WriteLine();

// Samlarobjekt som skall ersätta item1
Console.WriteLine("=== Uppdatera samlarobjekt (1) baserat på namn ===");
CollectionItem.UpdateItemByName(item1.ItemName, "Så som i himmelen", "En rörande dramakomedi om en berömd dirigent som återvänder till sin hemby och förändrar livet för invånarna där", 100, ItemCondition.Hyfsad, "Fodralet saknas.");
Console.WriteLine("=== Alla Samlarobjekt: Uppdaterd baserat på namn ===");
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}

// Samlarobjekt som skall ersätta item2
Console.WriteLine("=== Uppdatera samlarobjekt (2) baserat på ID ===");
CollectionItem.UpdateItemById(item2.ItemId, "Blade Runner", "En uppföljare till den klassiska Blade Runner, som utforskar frågor om mänsklighet och identitet i en dystopisk framtid.", 50, ItemCondition.Dåligt, "DVD-skivan är repad.");

Console.WriteLine("=== Alla Samlarobjekt: Uppdaterd baserat på namn ===");
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}

//Ta bort samlarobjekt baserat på namn
CollectionItem.RemoveItemByName(item2.ItemName);
Console.WriteLine("=== Alla samlarobjekt: Utan item2 ===");
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}

// Ta bort samlarobjekt baserat på ID
CollectionItem.RemoveItemById(item3.ItemId);
Console.WriteLine("=== Alla samlarobjekt: Utan item3 ===");
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}

decimal newValue = 500;
Console.WriteLine($"Uppdaterat värdet till {newValue} på samlarobjekt item1");
CollectionItem.EstimatedOwnValue(item1.ItemId, newValue);
foreach (var item in CollectionItem.GetAllItems())
{
    ShowAllItemInfo(item);
}
}

// Metod för att hämta info om alla samlarobjekt
private static void ShowAllItemInfo(CollectionItem item)
{
Console.WriteLine($"ID: {item.ItemId}");
Console.WriteLine($"Name: {item.ItemName}");
Console.WriteLine($"Beskrivning: {item.Description}");
Console.WriteLine($"Värde: {item.ItemValue}");
Console.WriteLine($"Skick: {item.Condition}");
Console.WriteLine($"Anteckningar: {item.Notes}");
Console.WriteLine();
}

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

Console.WriteLine("=== Hämta kategori baserat på ID (2) ===");
foreach (var category in Category.GetCategoryById(2))
{
    ShowCategoriesInfo(category);
    Console.WriteLine();
}

// Kategori som skall ersätta customCategory1
Console.WriteLine("=== Uppdatera kategori (7) baserat på namn ===");
Category.UpdateCategoryByName(customCategory1.CategoryName, "Lyxklockor", "Exempel: Sportklockor, Dressklockor");

Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori 7 ===");

foreach (var category in Category.GetAllCategories())
{
    ShowCategoriesInfo(category);
}

// Kategori som skall ersätta customCategory2
Console.WriteLine("=== Uppdatera kategori (8) baserat på ID ===");
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
*/



