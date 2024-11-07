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
            categories.Add(new Category("Litteratur & Böcker", "Olika format av litterära verk: Inbunden, Häftad, Pocket, E-bok, Kartonnage", CategoryType.Böcker));
            categories.Add(new Category("Film & Video", "Film- och videoformat: DVD, Blu-ray, VHS, LaserDisc, Betamax", CategoryType.Filmer));
            categories.Add(new Category("Musik & Ljudmedier", "Musikformat och ljudmedier: Vinylskiva, Kassettband, CD, MiniDisc", CategoryType.Musik));
            categories.Add(new Category("Leksaker & Figurer", "Olika typer av leksaker: LEGO, Figurer, Dockor, Pussel:", CategoryType.Leksaker));
            categories.Add(new Category("Spel & Interaktiv Media", "Digitala och analoga spel: TV-spel, Datorspel, Brädspel", CategoryType.Spel));
            categories.Add(new Category("Konst & Konsthantverk", "Olika konstformer: Målning, Skulptur, Keramik, Textiler", CategoryType.Konst));
        }

        // Publik konstrukor för att skapa en ny kategori
        public Category(string name, string description, CategoryType type)
        {
            CategoryId = nextId++;
            CategoryName = name;
            Description = description;
            Type = type;
            Items = new List<CollectionItem>();
        }

        // Lägger till en anpassad kategori till listan av kategorier
        public static Category AddCustomCategory(string name, string description)
        {
            var category = new Category(name, description, CategoryType.Custom);
            categories.Add(category);
            return category;
        }

        // Hämtar alla fördefinierade kategorier
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

        // Hämtar en kategori baserat på namn
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

        // Hämtar en kategori baserat på ID
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

        // Uppdaterar en kategori baserat på namn
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

        // Uppdaterar en kategori baserat på ID
        public static void UpdateCategoryById(int id, string newName, string newDescription)
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

        // Hämtar alla kategorier (både fördefinierade och anpassade)
        public static List<Category> GetAllCategories()
        {
            return categories;
        }
    }
}
