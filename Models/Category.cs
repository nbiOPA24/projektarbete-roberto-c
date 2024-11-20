using TheCollectorApp.Enums;

namespace TheCollectorApp.Models
{
    public class Category
    {
        private static int nextId = 1;
        // Lista som lagrar alla kategorier (både fördefinierade och anpassade)
        private static List<Category> categories = new List<Category>();

        public int CategoryId { get; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public CategoryType Type { get; }
        // Lista med alla samlingsobjekt som tillhör kategorin
        public bool IsStandard { get; } // True om kategorin är fördefinierad, annars False
        public List<CollectionItem> Items { get; set; }

        // En statisk konstruktor som körs när programmet startas (fördefinierade kategorier)
        static Category()
        {
            categories.Add(new Category("Litteratur & Böcker", "Olika format av litterära verk: Inbunden, Häftad, Pocket, E-bok, Kartonnage", CategoryType.Books, true));
            categories.Add(new Category("Film & Video", "Film- och videoformat: DVD, Blu-ray, VHS, LaserDisc, Betamax", CategoryType.Films, true));
            categories.Add(new Category("Musik & Ljudmedier", "Musikformat och ljudmedier: Vinylskiva, Kassettband, CD, MiniDisc", CategoryType.Music, true));
            categories.Add(new Category("Leksaker & Figurer", "Olika typer av leksaker: LEGO, Figurer, Dockor, Pussel", CategoryType.Toys, true));
            categories.Add(new Category("Spel & Interaktiv Media", "Digitala och analoga spel: TV-spel, Datorspel, Brädspel", CategoryType.Games, true));
            categories.Add(new Category("Konst & Konsthantverk", "Olika konstformer: Målning, Skulptur, Keramik, Textiler", CategoryType.Art, true));
        }

        // Publik konstruktor för att skapa en ny kategori. isStandard=false skapar en anpassad kategori, True skapar en fördefinierad kategori
        public Category(string name, string description, CategoryType type, bool isStandard = false) // isStandard är False när en användaren skapar en ny anpassad kategori
        {
            CategoryId = nextId++;
            CategoryName = name;
            Description = description;
            Type = type;
            Items = new List<CollectionItem>(); // En tom lista för samlarobjekt som tillhör kategorin
            IsStandard = isStandard;
        }

        // Skapar en anpassade kategori och lägger till den i listan categories
        public static Category AddCustomCategory(string name, string description)
        {
            var category = new Category(name, description, CategoryType.Custom);
            categories.Add(category);
            return category;
        }

        // Returnerar endast fördefinierade kategorier
        public static List<Category> GetAllStandardCategories()
        {
            var standardCategory = new List<Category>();

            foreach (var category in categories)
            {
                if (category.Type != CategoryType.Custom)
                {
                    standardCategory.Add(category);
                }
            }
            return standardCategory;
        }

        // Returnerar en kategori baserat på namn
        public static List<Category> GetCategoryByName(string name)
        {
            var categoryName = new List<Category>();

            foreach (Category category in categories)
            {
                if (category.CategoryName.Contains(name))
                {
                    categoryName.Add(category);
                }
            }
            return categoryName;
        }

        /*
                // Förenklad version av metoden GetCategoryByName. Returnerar en kategori baserat på namn
                public static Category? GetCategoryByName(string name) // Category? Kan returnera ett värde eller vara null
                {   // LINQ-metod FirstOrDefault returnerar första kategorin vars namn matchar det sökta namnet (texten). Ett Lambda-uttryck användas som sökvilkor.
                    return categories.FirstOrDefault(c => c.CategoryName.Contains(name));
                }
        */

        // Returnerar en kategori baserat på ID
        public static List<Category> GetCategoryById(int id)
        {
            var categoryId = new List<Category>();

            foreach (Category category in categories)
            {
                if (category.CategoryId == id)
                {
                    categoryId.Add(category);
                }
            }
            return categoryId;
        }

        /*
                // Förenklad version av metoden GetCategoryById. Returnerar en kategori baserat på ID
                public static Category? GetCategoryById(int id) // Category? Kan returnera ett värde eller vara null
                {   // LINQ-metod FirstOrDefault returnerar första kategorin vars ID matchar det sökta ID:t. Ett Lambda-uttryck användas som sökvilkor.
                    return categories.FirstOrDefault(c => c.CategoryId == id);
                }
        */

        // Uppdaterar namn och beskrivning för en kategori baserat på namn
        public static void UpdateCategoryByName(string name, string newName, string newDescription)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryName == name)
                {
                    category.CategoryName = newName;
                    category.Description = newDescription;
                    break;
                }
            }
        }

        // Uppdaterar namn och beskrivning för en kategori baserat på ID
        public static void UpdateCategoryById(int id, string newName, string newDescription)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryId == id)
                {
                    category.CategoryName = newName;
                    category.Description = newDescription;
                    break;
                }
            }
        }

        // Tar bort kategori baserat på namn
        public static void RemoveCategoryByName(string name)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryName == name)
                {
                    categories.Remove(category);
                    break;
                }
            }
        }

        // Ta bort kategori baserat på ID
        public static void RemoveCategoryById(int id)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryId == id)
                {
                    categories.Remove(category);
                    break;
                }
            }
        }

        // Returnerar alla kategorier (både fördefinierade och anpassade)
        public static List<Category> GetAllCategories()
        {
            return categories;
        }
    }
}
