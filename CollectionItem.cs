using Microsoft.VisualBasic;

namespace TheCollectorApp
{
	public class CollectionItem
	{
		private static int nextId = 1; // Ökar automatiskt med 1 för varje ny samlingsobjekt

        public int ItemId { get; }
		public string ItemName { get; set; }
		public string Description { get; set; }
		public decimal ItemValue { get; set; }
		public DateTime AddedDate { get; }
		public ItemCondition Condition { get; set; } // ändra till Enum i diagrammet
		public string Notes { get; set; }
		public List<Category> Categories { get; set; }

		// Lista för att spara alla objekt
		private static List<CollectionItem> items = new List<CollectionItem>();

		public CollectionItem(string name, string description, decimal itemValue, ItemCondition condition, string notes)
		{
			ItemId = nextId++; // Tilldelar nuvarande värdet. Sedan ökar den med ett steg
            ItemName = name;
			Description = description;
			ItemValue = itemValue;
			AddedDate = DateTime.Now;
			Condition = condition;
			Notes = notes;
			Categories = new List<Category>();
		}

		//CRUD metoder

		public static void AddItem(CollectionItem item)
		{
			items.Add(item);
		}


		public static CollectionItem? GetItem(int id)
		{
			foreach (CollectionItem item in items)
			{
				if (item.ItemId == id)
					return item;
			}
			return null;
		}


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

		// Sätter uppskattad värde för ett samlarobjektet
		public static void EstimatedValue(int id, decimal newValue)
		{
			foreach (CollectionItem item in items)
			{
				if (item.ItemId == id)
				{
					item.ItemValue = newValue;
					break;
				}
			}
		}
	}
}