class Program 
{
    static void Main() 
    {
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
    }
}
