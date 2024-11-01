namespace TheCollectorApp
{
    public class Category
    {
        // Privata egenskaper
        private static int nextId = 1;
        // Lista för att spara kategorier
        private static List<Category> categories = new List<Category>();

        public int CategoryId { get; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public CategoryType Type { get; }
        // läser och lägger till CollectionItem-objekt i listan
        public List<CollectionItem> Items { get; set; }

        // === Färdiga kategorier ===
        static Category()
        {
            categories.Add(new Category("Böcker", "Exempel: Inbunden, Häftad, Pocket, E-bok, Kartonnage", CategoryType.Böcker));
            categories.Add(new Category("Filmer", "Exempel: DVD, Blue-ray, VHS, LaserDisc, Betamax", CategoryType.Filmer));
            categories.Add(new Category("Musik", "Exemepl: Vinylskiva, Kassettband, CD, MiniDisc", CategoryType.Musik));
            categories.Add(new Category("Leksaker", "Exemepl: LEGO, Figurer, Dockor, Pussel:", CategoryType.Leksaker));
            categories.Add(new Category("Spel", "Exempel: TV-spel, Datorspel, Brädspel", CategoryType.Spel));
            categories.Add(new Category("Konst", "Exempel: Målning, Skulptur, Keramik, Textiler", CategoryType.Konst));
        }

        // === Skapa egna kategorier ===
        public Category(string name, string description, CategoryType type)
        {
            CategoryId = nextId++;
            CategoryName = name;
            Description = description;
            Type = type;
            Items = new List<CollectionItem>();
        }

        // CRUD-metoder för kategorier man skapar själv
        public static Category AddCustomCatetegory(string name, string description)
        {
            var category = new Category(name, description, CategoryType.Custom);
            categories.Add(category);
            return category;
        }

        // Hämtar alla standard kategorier
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

        // Hämta kategori med ID
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

        // Hämtar alla standard kategorier och dem man har skapat själv.
        public static List<Category> GetAllCategories()
        {
            return categories;
        }
    }
}