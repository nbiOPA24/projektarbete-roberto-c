namespace TheCollectorApp
{
	public class CollectionItem
	{
		private static int nextId = 1; // Ökar automatiskt med 1 för varje ny samlingsobjekt
		private static List<CollectionItem> items = new List<CollectionItem>();

		public int ItemId { get; }
		public string ItemName { get; set; }
		public string Description { get; set; }
		public decimal ItemValue { get; set; }
		public DateTime AddedDate { get; }
		public ItemCondition Condition { get; set; }
		public string Notes { get; set; }
		//List över kategorier som samlarobjektet tillhör
		public List<Category> Categories { get; set; }

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

		public static void AddItem(CollectionItem item)
		{
			items.Add(item);
		}

		// Retunerar ett samlarobjekt baserat på namn
		public static List<CollectionItem> GetItemByName(string name)
		{
			var itemName = new List<CollectionItem>();

			foreach (CollectionItem item in items)
			{
				if (item.ItemName.Contains(name))
				{
					itemName.Add(item);
				}
			}
			return itemName;
		}

		// Retunerar ett samlarobjekt baserat på ID
		public static List<CollectionItem> GetItemById(int id)
		{
			var itemId = new List<CollectionItem>();

			foreach (CollectionItem item in items)
			{
				if (item.ItemId == id)
				{
					itemId.Add(item);
				}
			}
			return itemId;
		}

		// Uppdaterar ett samlarobjekt baserat på namn 
		public static void UpdateItemByName(string name, string newName, string newDescription, decimal newValue, ItemCondition newCondition, string newNotes)
		{
			foreach (CollectionItem item in items)
			{
				if (item.ItemName == name)
				{
					item.ItemName = newName;
					item.Description = newDescription;
					item.ItemValue = newValue;
					item.Condition = newCondition;
					item.Notes = newNotes;
				}
			}
		}

		// Uppdaterar ett samlarobjekt baserat på ID 
		public static void UpdateItemById(int id, string newName, string newDescription, decimal newValue, ItemCondition newCondition, string newNotes)
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

		// Tar bort ett samlarobjekt baserat på namn
		public static void RemoveItemByName(string name)
		{
			foreach (CollectionItem item in items)
			{
				if (item.ItemName == name)
				{
					items.Remove(item);
					break;
				}
			}
		}

		// Ta bort samlarobjekt baserat på ID
		public static void RemoveItemById(int id)
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

		// Retunerar alla samlarobjekt från en lista
		public static List<CollectionItem> GetAllItems()
		{
			return items;
		}

		// Uppdaterar värdet på ett samlarobjekt baserat på ID
		public static void EstimatedOwnValue(int id, decimal newValue)
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
