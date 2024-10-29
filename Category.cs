public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    // läser och lägger till CollectionItem-objekt i listan.
    public List<CollectionItem> Items { get; set; }

    // Lista för att spara kategorier
    private static List<Category> categories = new List<Category>();

    public Category(int id, string name, string description)
    {
        CategoryId = id;
        CategoryName = name;
        Description = description;
        Items = new List<CollectionItem>();
    }

    // Likt CRUD

    // Create
    public static void AddCatetegory(Category category)
    {
        categories.Add(category);
    }

    // Read
    public static Category GetCategory(int id)
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

    // Upate. OBS: skall läggas till i diagrammet 
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

    // Delete
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

    // Visa alla kategorier. OBS: skall läggas till i diagrammet 
    public static List<Category> GetAll()
    {
        return categories;
    }
}