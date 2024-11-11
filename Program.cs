using System;
using TheCollectorApp;

class Program
{
    static void Main()
    {
        // === Testar klassen Collection === 

        Console.WriteLine("=== Skapar en ny användare med samlingar ===");

        // Skapar 3 st. användare till samlingarna
        var user = new User("Björn", "Barg", "bjornen", "bjorn123", "bjorn@mail.com");
        var user2 = new User("Ulf", "Stålman", "stalmannen", "stalmannen123", "stalman@mail.com");
        var user3 = new User("Tore", "Falk", "falken", "falk123", "falk@mail.com");
        ShowUserInfo(user);
        ShowUserInfo(user2);
        ShowUserInfo(user3);

        // Skapar 3 typer av anpassade samlingar
        var collection1 = new Collection("Min samling av böcker", "En samling med svenska böcker", CollectionType.MusicCollection, user, false);
        var collection2 = new Collection("Min VHS-samlning", "En samling med filmer från 80-talet", CollectionType.FilmCollection, user2, false);
        var collection3 = new Collection("Min samling av figurer", "En samling med äldre figurer från Disney", CollectionType.Custom, user3, false);

        // Lägger till samlingar till listan
        Collection.AddCollection(collection1);
        Collection.AddCollection(collection2);
        Collection.AddCollection(collection3);

        // Skapar "samlingsobjekt" 
        var item1 = new CollectionItem("En man som heter Ove", "En svensk roman om en surmulen äldre man som sakta dras in i grannarnas liv och blir påverkad av deras värme och vänlighet. ", 199, ItemCondition.Decent, "Boken är lite sliten på den första sidan.");
        var item2 = new CollectionItem("The Matrix", "Filmen är en sci-fi-film där en hacker upptäcker att verkligheten är en simulering styrd av maskiner, och han måste kämpa för mänsklighetens frihet.", 99, ItemCondition.Poor, "Film är trasig och går inte att använda. Men är ett bra minne och kan ställas i bokhyllan.");
        var item3 = new CollectionItem("Musse Pigg-figur: Limited Edition-figurer", "Speciella samlarobjekt som producerats i begränsad upplaga, ofta av företag som Disney Store eller Hallmark.", 19999, ItemCondition.Excellent, "Figuren har varit bevarad i en glasmonter på ett museum.");

        // lägger till samlingsobjekt till respektive samling
        collection1.AddItemToCollection(item1);
        collection2.AddItemToCollection(item2);
        collection3.AddItemToCollection(item3);


        Console.WriteLine("=== Bara alla anpassade samlingar (ID: 7, 8, 9) ===");
        foreach (var collection in Collection.GetAllCustomCollections())
        {
            ShowCollectionInfo(collection);
        }

        Console.WriteLine("=== Bara alla fördefinierade samlingar (ID: 1-6) ===");
        foreach (var collection in Collection.GetAllStandardCollections())
        {
            ShowCollectionInfo(collection);
        }

        Console.WriteLine("=== Alla fördefinierade & Anpassade samlingar ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            ShowCollectionInfo(collection);
        }
        Console.WriteLine();

        Console.WriteLine("=== Hämtar samling baserat på namn ===");
        foreach (var collection in Collection.GetCollectionByName("Min samling av böcker"))
        {
            ShowCollectionInfo(collection);
        }

        Console.WriteLine("=== Hämtar samling baserat på ID ===");
        foreach (var collection in Collection.GetCollectionById(3))
        {
            ShowCollectionInfo(collection);
        }

        // Samling som skall ersätta collection1 baserat på namn
        Collection.UpdateCollectionByName(collection1.CollectionName, "Min samling av tyska mynt", "En samling med gamla tyska mynt.");

        Console.WriteLine("=== Uppdaterar samling baserat på namn (Min samling av böcker) ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            ShowCollectionInfo(collection);
        }
        Console.WriteLine();

        // Uppdaterar samling med ID 9
        Collection.UpdateCollectionById(collection3.CollectionId, "Superhjältefigur: Limited Edition-Actionfigur", "En exklusiv och detaljerad actionfigur av en superhjälte från ett populärt serieuniversum, ofta släppt i begränsad upplaga.");

        Console.WriteLine("=== Uppdaterar samling baserat på ID (9) ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            ShowCollectionInfo(collection);
        }

        // Ta bort samling baserat på namn
        Collection.RemoveCollectionByName(collection1.CollectionName);
        Console.WriteLine("=== Tar bort samling baserat på namn ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            ShowCollectionInfo(collection);
        }

        // Ta bort samling baserat på ID
        Collection.RemoveCollectionById(collection2.CollectionId);
        Console.WriteLine("=== Tar bort samling baserat på ID ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            ShowCollectionInfo(collection);
        }

        Console.WriteLine("=== Visar info om samling och tillhörande samlingsobjekt ===");
        foreach (var collection in Collection.GetAllCollections())
        {
            Console.WriteLine($"Samling: {collection2.CollectionName}");
            Console.WriteLine($"Samlarobjekt i samlingen: ");
            foreach (var item in collection2.Items)
            {
                ShowAllItemInfo(item);
            }
        }
    }

    // === metoder som hjälper till med utskrift ===
    private static void ShowAllItemInfo(CollectionItem item)
    {
        Console.WriteLine($"ID: {item.ItemId}");
        Console.WriteLine($"Name: {item.ItemName}");
        Console.WriteLine($"Beskrivning: {item.Description}");
        Console.WriteLine($"Värde: {item.ItemValue:C}"); // C: formas till valuta
        Console.WriteLine($"Skick: {item.Condition}");
        Console.WriteLine($"Anteckningar: {item.Notes}");
        Console.WriteLine();
    }

    private static void ShowUserInfo(User user)
    {
        Console.WriteLine($"ID: {user.UserId}");
        Console.WriteLine($"Förnamn och efternamn: {user.FirstName} {user.SecondName}");
        Console.WriteLine($"Användarnamn: {user.UserName}");
        Console.WriteLine($"E-post: {user.Email}");
        Console.WriteLine();
    }

    private static void ShowCollectionInfo(Collection collection)
    {
        Console.WriteLine($"ID: {collection.CollectionId}");
        Console.WriteLine($"Samlingsnamn: {collection.CollectionName}");
        Console.WriteLine($"Beskrivning: {collection.Description}");
        Console.WriteLine($"Typ: {collection.Type}");
        Console.WriteLine($"Ägare: {collection.Owner?.FirstName ?? "Ingen ägare"}");
        Console.WriteLine($"Skapade: {collection.CreateDate}");
        Console.WriteLine($"Antal objekt: {collection.Items.Count}");
        Console.WriteLine($"Variant: {(collection.IsStandard ? "Fördefinierad" : "Anpassad")}");
    }
}

/*
// Första versionen av en meny...
while (true)
{
    Console.WriteLine("==== SAMLARAPPEN ====");
    Console.WriteLine("Välkommen! Skapa gärna ett användarkonto eller logga in om du har ett.");
    Console.WriteLine("Du kan enkelt ändra dina samlingar genom ta skriva namn eller ID-nummer.");
    Console.WriteLine();
    Console.WriteLine("==== KONTO & INLOGGNING ====");
    Console.WriteLine("1. Skapa ett användarkonto");
    Console.WriteLine("2. Logga in");
    Console.WriteLine("3. Logga ut");
    Console.WriteLine();

    Console.WriteLine("=== KONTOHANTERING ===");
    Console.WriteLine("4. Se kontouppgifter ");
    Console.WriteLine("5. Uppdatera uppgifter");
    Console.WriteLine("6. Ta bort konto ");
    Console.WriteLine();

    Console.WriteLine("=== SAMLINGAR ===");
    Console.WriteLine("7. Visa mina samlingar");
    Console.WriteLine("8. Skapa en ny samling");
    Console.WriteLine("9. Välj en färdig samling");
    Console.WriteLine("10. Uppdatera samling");
    Console.WriteLine("11. Ta bort samling");
    Console.WriteLine();

    Console.WriteLine("=== SAMLINGSOBJEKT ===");
    Console.WriteLine("12. Se mina samlingsobjekt");
    Console.WriteLine("13. Lägg till nytt samlingsobjekt");
    Console.WriteLine("14. Uppdatera samlingobjekt");
    Console.WriteLine("15. Ta bort samlingsobjekt");
    Console.WriteLine();

    Console.WriteLine("==== KATEGORI ====");
    Console.WriteLine("16. Visa alla kategorier");
    Console.WriteLine("17. Lägg till ny kategori");
    Console.WriteLine("18. Uppdatera kategori");
    Console.WriteLine("19. Ta bort kategori");

    Console.WriteLine();
    Console.WriteLine("20. Avsluta");

    string choice = Console.ReadLine();

    if (choice == "20")
    {
        Console.WriteLine("Programmet avslutas. Hej då!");
        break;
    }
    switch (choice)
    {
        case "1":
            Console.WriteLine();
            break;
        case "4":
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("Ogiltigt val");
            break;
    }
    Console.WriteLine();
}
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
}


// === Testar klassen Collection === 

Console.WriteLine("=== Skapar en ny användare med samlingar ===");

// Skapar en användare till samlingarna
var user = new User("Björn", "Barg", "bjornen", "bjorn123", "bjorn@mail.com");
ShowUserInfo(user);

// Skapar olika typer av samlingar
var collection1 = new Collection("Min CD-samling", "En samling med hårdrocksmusik", CollectionType.Musiksamling, user);
var collection2 = new Collection("Min VHS-samlning", "En samling med filmer från 80-talet", CollectionType.Filmsamling, user);
var collection3 = new Collection("Min samlning av finska mynt", "En samling med gamla mynt från Finland", CollectionType.Myntsamling, user);
Collection.AddCollection(collection1);
Collection.AddCollection(collection2);
Collection.AddCollection(collection3);

// Skapar samlingsobjekt
var item1 = new CollectionItem("En man som heter Ove", "En svensk roman om en surmulen äldre man som sakta dras in i grannarnas liv och blir påverkad av deras värme och vänlighet. ", 199, ItemCondition.MycketBra, "Boken är lite sliten på den första sidan.");
var item2 = new CollectionItem("The Matrix", "Filmen är en sci-fi-film där en hacker upptäcker att verkligheten är en simulering styrd av maskiner, och han måste kämpa för mänsklighetens frihet.", 99, ItemCondition.Dåligt, "Film är trasig och går inte att använda. Men är ett bra minne och kan ställas i bokhyllan.");
var item3 = new CollectionItem("Musse Pigg-figur: Limited Edition-figurer:", "Speciella samlarobjekt som producerats i begränsad upplaga, ofta av företag som Disney Store eller Hallmark.", 19999, ItemCondition.Utmärkt, "Figuren har varit bevarad i en glasmonter på ett museum.");
collection2.AddItemToCollection(item2);

Console.WriteLine("=== Skapade samlingar med ID: 1, 2, 3 ===");
foreach (var collection in Collection.GetAllCollections())
{
ShowCollectionInfo(collection);
}

Console.WriteLine("=== Hämta samling baserat på namn ===");
foreach (var collection in Collection.GetCollectionByName("Min CD-samling"))
{
ShowCollectionInfo(collection);
}

Console.WriteLine("=== Hämta samling baserat på ID ===");
foreach (var collection in Collection.GetCollectionById(3))
{
ShowCollectionInfo(collection);
}

// Samling som skall ersätta collection1
Collection.UpdateCollectionByName(collection1.CollectionName, "Min samling av tyska mynt", "En samling med gamla tyska mynt.");

Console.WriteLine("=== Uppdaterar samling baserat på id ===");
foreach (var collection in Collection.GetAllCollections())
{
ShowCollectionInfo(collection);
}
Console.WriteLine();

// Uppdaterar samling med ID 3
Collection.UpdateCollectionById(collection3.CollectionId, "Min samling av kassettband", "En samling med klassiskt musik på kassettband.");

Console.WriteLine("=== Uppdaterar samling baserat på namn ===");
foreach (var collection in Collection.GetAllCollections())
{
ShowCollectionInfo(collection);
}

// Ta bort samling baserat på namn
Collection.RemoveCollectionByName(collection1.CollectionName);

Console.WriteLine("=== Tar bort samling baserat på namn ===");
foreach (var collection in Collection.GetAllCollections())
{
ShowCollectionInfo(collection);
}

// Ta bort samling baserat på ID
Collection.RemoveCollectionById(collection2.CollectionId);

Console.WriteLine("=== Tar bort samling baserat på ID ===");
foreach (var collection in Collection.GetAllCollections())
{
ShowCollectionInfo(collection);
}

Console.WriteLine("=== Visar info om samling och tillhörande samlingsobjekt ===");
foreach (var collection in Collection.GetAllCollections())
{
Console.WriteLine($"Samling: {collection2.CollectionName}");
Console.WriteLine($"Samlarobjekt i samlingen: ");
foreach (var item in collection2.Items)
{
ShowAllItemInfo(item);
}
}
}

// === metoder som hjälper till med utskrift ===
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

private static void ShowUserInfo(User user)
{
Console.WriteLine($"Förnamn och efternamn: {user.FirstName} {user.SecondName}");
Console.WriteLine($"Användarnamn: {user.UserName}");
Console.WriteLine($"E-post: {user.Email}");
Console.WriteLine();
}

private static void ShowCollectionInfo(Collection collection)
{
Console.WriteLine($"ID: {collection.CollectionId}");
Console.WriteLine($"Samlingsnamn: {collection.CollectionName}");
Console.WriteLine($"Beskrivning: {collection.Description}");
Console.WriteLine($"Typ: {collection.Type}");
Console.WriteLine($"Ägare: {collection.Owner}");
Console.WriteLine($"Skapade: {collection.CreateDate}");
Console.WriteLine($"Antal objekt: {collection.Items.Count}");
}
}



// === Testar klassen Category ===

Console.WriteLine("=== Alla fördefinierade kategorier (1-6)===");
foreach (var category in Category.GetAllStandardCategories())
{
ShowCategoriesInfo(category);
}

Console.WriteLine("=== Skapar anpassade kategorier (ID: 7, 8, 9) ===");
var customCategory1 = Category.AddCustomCategory("Mynt & Numismatik", "Olika typer av mynt och sedlar: Guldmynt, Kopparmynt, Mynthäften");
var customCategory2 = Category.AddCustomCategory("Smycken & Ädelstenar", "Olika typer av smycken och accessoarer: Klockor, Ringar, Halsband");
var customCategory3 = Category.AddCustomCategory("Motorcyklar", "Olika typer av motorcyklar: Sportmotorcyklar, Cruisers, Touringmotorcyckel");
Console.WriteLine();

Console.WriteLine("=== Alla Kategorier: Fördefinierade & Anpassade (ID: 1-9) ===");
foreach (var category in Category.GetAllCategories())
{
ShowCategoriesInfo(category);
}

Console.WriteLine("=== Hämtar kategori baserat på namn (Mynt) ===");
foreach (var category in Category.GetCategoryByName("Mynt"))
{
ShowCategoriesInfo(category);
}

Console.WriteLine("=== Hämtar kategori baserat på ID (ID: 2) ===");
foreach (var category in Category.GetCategoryById(2))
{
ShowCategoriesInfo(category);
Console.WriteLine();
}

// Kategori som skall ersätta customCategory1
Console.WriteLine("=== Uppdaterar kategori baserat på namn ===");
Category.UpdateCategoryByName(customCategory1.CategoryName, "Lyxklockor", "Exempel: Sportklockor, Dressklockor");

Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori 7 ===");

foreach (var category in Category.GetAllCategories())
{
ShowCategoriesInfo(category);
}

// Kategori som skall ersätta customCategory2
Console.WriteLine("=== Uppdatera kategori baserat på ID (8) ===");
Category.UpdateCategoryById(customCategory2.CategoryId, "Skor", "Exempel: Vardagsskor, Träningskor, Finskor");
Console.WriteLine();

Console.WriteLine("=== Alla Kategorier: Med uppdaterd kategori ID 7 ===");
foreach (var category in Category.GetAllCategories())
{
ShowCategoriesInfo(category);
}

//Ta bort kategori baserat på namn
Category.RemoveCategoryByName(customCategory2.CategoryName);

Console.WriteLine("=== Alla Kategorier: Utan kategori ID 8 ===");
foreach (var category in Category.GetAllCategories())
{
ShowCategoriesInfo(category);
}

// Ta bort kategori baserat på ID
Category.RemoveCategoryById(customCategory1.CategoryId);
Console.WriteLine("=== Alla Kategorier: Utan kategori ID 7 ===");
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
}

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


*/



