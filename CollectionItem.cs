public enum ItemCondition
{
	Daligt,
	Hyfsad,
	Bra,
	MycketBra, //Mellanslag med PascalCase
	Utmarkt
}

public class CollectionItem
{
	public int ItemId { get; set; }
	public string ItemName { get; set; }
	public string Description { get; set; }
	public decimal ItemValue { get; set; }
	public DateTime AddedDate { get; set; } // �ndra i referensnamnet
	public ItemCondition Condition { get; set; } // �ndra till Enum i diagrammet
	public string Notes { get; set; }
	public List<Category> Categories { get; set; }

	// Lista f�r att spara alla objekt
	private static List<CollectionItem> items = new List<CollectionItem>();

	public CollectionItem(int id, string name, string description, decimal itemValue, ItemCondition condition, string notes)
	{
		ItemId = id;
		ItemName = name;
		Description = description;
		ItemValue = itemValue;
		AddedDate = DateTime.Now;
		Condition = condition;
		Notes = notes;
		Categories = new List<Category>();
	}

	// Likt CRUD

	// Create
	public static void AddItem(CollectionItem item)
	{
		items.Add(item);
	}


	// Read - Hämtar en item
	public static CollectionItem GetItem(int id)
	{
		foreach (CollectionItem item in items)
		{
			if (item.ItemId == id)
			{
				return item;
			}
		}
		return null;
	}

	// Update
	public static void UpdateItem(int id, string newName, string newDescription, decimal newValue, ItemCondition newCondition, string newNotes)
	{
		foreach (CollectionItem item in items)
		{
			if (item.ItemId == id)
			{
				item.ItemName = newName;
				item.Description = newDescription;
				item.ItemValue = newValue;
				item.Condition = newCondition;
				item.Notes = newNotes;
			}
		}
	}

	// Delete
	public static void RemoveItem(int id)
	{
		foreach (CollectionItem item in items)
		{
			if (item.ItemId == id)
			{
				items.Remove(item);
				break;
			}
		}
	}

	// Retunerar alla samlarobjekt från listan
	public static List<CollectionItem> GetAll()
	{
		return items;
	}
}
