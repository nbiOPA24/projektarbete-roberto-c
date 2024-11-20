using System.ComponentModel.DataAnnotations;
using TheCollectorApp.Enums;

namespace TheCollectorApp.Models
{
	public class CollectionItem
	{
		private static int nextId = 1; // Ökar automatiskt med 1 för varje nytt samlingsobjekt
									   // Lista som lagrar alla samlingsobjekt
		private static List<CollectionItem> items = new List<CollectionItem>();
		public int ItemId { get; }
		public string ItemName { get; set; }
		public string Description { get; set; }
		public decimal ItemValue { get; set; }
		public DateTime AddedDate { get; }
		public ItemCondition Condition { get; set; }
		public string Notes { get; set; }

		public bool IsExempelObject { get; } // True om samlingen är fördefinierad, annars False

		// List över kategorier som samlingsobjektet tillhör
		public List<Category> Categories { get; set; }

		// En statisk konstruktor med testobjekt som körs en gång när programmet startar
		static CollectionItem()
		{
			// Exempelobjekt utan användare
			items.Add(new CollectionItem("Exempelobjekt", "Detta är en testprodukt", 10, ItemCondition.Decent, "Detta är ett exempelobjekt"));
		}

		public CollectionItem(string name, string description, decimal itemValue, ItemCondition condition, string notes, bool isExempelObject = false)
		{
			ItemId = nextId++; // Tilldelar nuvarande värdet. Sedan ökar den med ett steg
			ItemName = name;
			Description = description;
			ItemValue = itemValue;
			AddedDate = DateTime.Now;
			Condition = condition;
			Notes = notes;
			IsExempelObject = isExempelObject;
			Categories = new List<Category>(); // En tom lista för kategorier som samlarobjektet tillhör
		}

		public static void AddItem(CollectionItem item)
		{
			items.Add(item);
		}

		// Returnerar ett samlarobjekt baserat på namn
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

		// Returnerar ett samlarobjekt baserat på ID
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

		// Uppdaterar egenskaper för ett samlarobjekt baserat på namn 
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
					break;
				}
			}
		}

		// Uppdaterar egenskaper för ett samlarobjekt baserat på ID 
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
					break;
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

		// Tar bort samlarobjekt baserat på ID
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

		// Returnerar alla samlingsobjekt från en lista
		public static List<CollectionItem> GetAllItems()
		{
			return items;
		}

		// Uppdaterar det uppskattade värdet på ett samlingsobjekt baserat på ID
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
