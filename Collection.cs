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
        public User Owner { get; set; } // Har lagt till "set" för att kunna uppdatera användare.

        // En statisk konstrukor som körs när programmet startas (fördefinierade samlingar)
        static Collection()
        {
            // Fördefinierade samlingar utan ägare (owner är därför null)
            collections.Add(new Collection("Boksamling", "En samling med musik", CollectionType.BookCollection, null));
            collections.Add(new Collection("Filmsamling", "En samling med musik", CollectionType.FilmCollection, null));
            collections.Add(new Collection("Musiksamling", "En samling med musik", CollectionType.MusicCollection, null));
            collections.Add(new Collection("Leksakssamling", "En samling med musik", CollectionType.ToyCollection, null));
            collections.Add(new Collection("Spelsamling", "En samling med musik", CollectionType.GameCollection, null));
            collections.Add(new Collection("Konstsamling", "En samling med musik", CollectionType.ArtCollection, null));
        }

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

        // Hämtar en samling baserat på namn
        public static List<Collection> GetCollectionByName(string name)
        {
            var collectionName = new List<Collection>();

            foreach (Collection collection in collections)
            {
                if (collection.CollectionName.Contains(name))
                {
                    collectionName.Add(collection);
                }
            }
            return collectionName;
        }

        // Hämtar en samling baserat på ID
        public static List<Collection> GetCollectionById(int id)
        {
            var collectionId = new List<Collection>();

            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                {
                    collectionId.Add(collection);
                }
            }
            return collectionId;
        }

        // Uppdaterar en samling baserat på namn
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

        // Uppdaterar en samling baserat på ID
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

        // Tar bort en samling baserat på namn
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

        // Tar bort en samling baserat på ID
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