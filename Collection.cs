using System;
using System.Collections.Generic;

namespace TheCollectorApp
{
    public class Collection
    {
        private static int nextId = 1; // Ökar automatiskt med 1 för varje ny samling

        //Lista för alla samlingar
        private static List<Collection> collections = new List<Collection>();

        public int CollectionId { get; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        // Olika typer av färdiga samlingar att välja mellan
        public CollectionType Type { get; }

        public List<CollectionItem> Items { get; set; }

        public DateTime CreateDate { get; }
        public User Owner { get; }

        public Collection(string collectionName, string description, CollectionType type, User owner)
        {
            CollectionId = nextId++; // Tilldelar nuvarande värdet. Sedan ökar den med ett steg
            CollectionName = collectionName;
            Description = description;
            Type = type;
            Owner = owner;
            CreateDate = DateTime.Now;
            Items = new List<CollectionItem>();
        }

        // Lägger till en samling
        public static void AddCollection(Collection collection)
        {
            collections.Add(collection);
        }

        // Hämtar samling baserat på namn
        public static Collection GetCollectionByName(string name)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionName == name)
                    return collection;
            }
            return null;
        }

        // Hämtar samling baserat på ID
        public static Collection GetCollectionById(int id)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                    return collection;
            }
            return null;
        }

        // Uppdaterar samling baserat namn
        public static void UpdateCollectionByName(string name, string newCollectionName, string newDescription)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionName == name)
                {
                    collection.CollectionName = newCollectionName;
                    collection.Description = newDescription;
                }
            }
        }

        // Uppdaterar samling baserat på ID
        public static void UpdateCollectionById(int id, string newCollectionName, string newDescription)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                {
                    collection.CollectionName = newCollectionName;
                    collection.Description = newDescription;
                }
            }
        }

        // Tar bort samling baserat på namn
        public static void RemoveCollectionByName(string name)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionName == name)
                {
                    collections.Remove(collection);
                    break;
                }
            }
        }

        // Tar bort samling baserat på ID
        public static void RemoveCollectionById(int id)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                {
                    collections.Remove(collection);
                    break;
                }
            }
        }

        // Hämtar alla samlingar
        public static List<Collection> GetAllCollections()
        {
            return collections;
        }

        // === Samlarobjekt ===

        // Lägger till samlarobjekt till samling
        public void AddItemToCollection(CollectionItem items)
        {
            Items.Add(items);
        }
    }
}