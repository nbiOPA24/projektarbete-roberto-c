namespace TheCollectorApp
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

        // Lista över alla samlarobjekt som tillhör kategorin 
        public List<CollectionItem> Items { get; set; }

        // En statisk konstrukor som skapar fördefinierade kategorier
        static Category()
        {
            categories.Add(new Category("Böcker", "Exempel: Inbunden, Häftad, Pocket, E-bok, Kartonnage", CategoryType.Böcker));
            categories.Add(new Category("Filmer", "Exempel: DVD, Blue-ray, VHS, LaserDisc, Betamax", CategoryType.Filmer));
            categories.Add(new Category("Musik", "Exemepl: Vinylskiva, Kassettband, CD, MiniDisc", CategoryType.Musik));
            categories.Add(new Category("Leksaker", "Exemepl: LEGO, Figurer, Dockor, Pussel:", CategoryType.Leksaker));
            categories.Add(new Category("Spel", "Exempel: TV-spel, Datorspel, Brädspel", CategoryType.Spel));
            categories.Add(new Category("Konst", "Exempel: Målning, Skulptur, Keramik, Textiler", CategoryType.Konst));
        }

        // publik konstrukor för att skapa en ny kategory
        public Category(string name, string description, CategoryType type)
        {
            CategoryId = nextId++;
            CategoryName = name;
            Description = description;
            Type = type;
            Items = new List<CollectionItem>();
        }

        // CRUD-metoder

        public static Category AddCustomCatetegory(string name, string description)
        {
            var category = new Category(name, description, CategoryType.Custom);
            categories.Add(category);
            return category;
        }

        // Hämtar alla fördefinierade kategorier
        public static List<Category> GetStandardCategory()
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

        // Hämtar en kategori baserat på ID
        public static Category? GetCategory(int id)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryId == id)
                {
                    return category;
                }
            }
            return null;
        }

        public static void UpdateCategory(int id, string newName, string newDescription)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryId == id)
                {
                    category.CategoryName = newName;
                    category.Description = newDescription;
                }
            }
        }

        public static void RemoveCategory(int id)
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

        // Hämtar alla kategorier (både fördefinierade och anpassade)
        public static List<Category> GetAllCategories()
        {
            return categories;
        }
    }
}