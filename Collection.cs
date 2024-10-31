using System;
using System.Collections.Generic;

namespace TheCollectorApp
{
    public class Collection
    {
        private static int nextId = 1; // Ökar automatiskt med 1 för varje ny samling

        //Lista för alla samlingar
        private static List<Collection> collections = new List<Collection>();

        public int CollectionId { get; }// ID ska endast finnas för egna skapta samlingar och får ej ändras
        public string Name { get; set; }
        public string Description { get; set; }
        public CollectionType Type { get; } // Olika typer av färdiga samlingar att välja mellan
        
        public List<CollectionItem> Items { get; set; }
        
        public DateTime CreateDate { get; }
        public User Owner { get; }



        public Collection(string name, string description, CollectionType type, User owner)
        {
            CollectionId = nextId++; // Tilldelar nuvarande värdet. Sedan ökar den med ett steg
            Name = name;
            Description = description;
            Type = type;
            Owner = owner;
            CreateDate = DateTime.Now;
            Items = new List<CollectionItem>();
        }

        // CRUD metoder

        public static void AddCollection(Collection collection) 
        {
            collections.Add(collection);
        }

        public static Collection GetCollection(int id) 
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                    return collection;
            }
            return null;
        }

        public static void UpdateCollection(int id, string newName, string newDescription) 
        {
            foreach (Collection collection in collections) 
            {
                if (collection.CollectionId == id) 
                {
                    collection.Name = newName;
                    collection.Description = newDescription;
                }
            }
        }

        public static void RemoveCollection(int id) 
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

        // retunerar alla samlingar
        public static List<Collection> GetAllCollections() 
        {
            return collections;
        }

        // === Item ===

        public void AddItemToCollection(CollectionItem items) 
        {
            Items.Add(items);
        }



    }
}