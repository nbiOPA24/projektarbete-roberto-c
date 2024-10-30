class Program
{
    static void Main()
    {

        //=== Testar klassen CollectionItem ===

        CollectionItem itemBook = new CollectionItem(101, "Boken", "En bra bok som handlar om läsning", 199, ItemCondition.MycketBra, "Boken är lite sliten på första sidan.");
        CollectionItem itemMusic = new CollectionItem(201, "Filmen", "En film som handlar om en film", 99, ItemCondition.Daligt, "Film är trasig och går inte att använda. Men är ett bra minne och kan ställas i bokhyllan.");
        CollectionItem itemToy = new CollectionItem(301, "Musse pig figur", "En äldre figur från Disney", 1999, ItemCondition.Utmarkt, "Figuren har varit bevarad i en glasmonter på ett museum.");

        // Lägg till samlarobjekt
        CollectionItem.AddItem(itemBook);
        CollectionItem.AddItem(itemMusic);
        CollectionItem.AddItem(itemToy);

        Console.WriteLine("Alla objekt innan remove metoden används");
        VisaAllaObjekt();

        Console.WriteLine("Tar bort objekt");
        CollectionItem.RemoveItem(201);

        Console.WriteLine("Alla objekt efter remove metoden används");
        VisaAllaObjekt();

        static void VisaAllaObjekt()
        {
            Console.WriteLine("Alla samlarobjekt:");
            foreach (CollectionItem item in CollectionItem.GetAll())
            {
                Console.WriteLine($"ID: {item.ItemId}");
                Console.WriteLine($"Name: {item.ItemName}");
                Console.WriteLine($"Värde: {item.ItemValue}");
                Console.WriteLine($"Skick: {item.Condition}");
                Console.WriteLine($"Beskrivning: {item.Description}");
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
        */
    }
}
