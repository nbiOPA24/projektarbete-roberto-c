using System.Reflection.Metadata;

namespace TheCollectorApp
{
    public class Collection
    {
        private static int nextId = 1; // Ökar automatiskt med 1 för varje ny samling
        // Lista som lagrar alla samlingar
        private static List<Collection> collections = new List<Collection>();

        public int CollectionId { get; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        // Olika typer av samlingar att välja mellan, kan vara fördefinierade eller anpassade
        public CollectionType Type { get; }
        public DateTime CreateDate { get; }
        public User? Owner { get; set; } // Hämtar eller sätter en användare för samlingen. Kan vara null
        public bool IsStandard { get; } // True om samlingen är fördefinierad, annars False
        public List<CollectionItem> Items { get; set; }

        // En statisk konstruktor med fördefinierade samlingar som körs en gång när programmet startar
        static Collection()
        {
            // Fördefinierade samlingar utan användare (owner är därför null)
            collections.Add(new Collection("Boksamling", "En samling med böcker", CollectionType.BookCollection, null, true));
            collections.Add(new Collection("Filmsamling", "En samling med filmer", CollectionType.FilmCollection, null, true));
            collections.Add(new Collection("Musiksamling", "En samling med musik", CollectionType.MusicCollection, null, true));
            collections.Add(new Collection("Leksakssamling", "En samling med leksaker", CollectionType.ToyCollection, null, true));
            collections.Add(new Collection("Spelsamling", "En samling med spel", CollectionType.GameCollection, null, true));
            collections.Add(new Collection("Konstsamling", "En samling med konst", CollectionType.ArtCollection, null, true));
        }

        public Collection(string collectionName, string description, CollectionType type, User? owner, bool isStandard = false) // isStandard är false när användaren skapar en ny anpassad samling
        {
            CollectionId = nextId++; // Tilldelar nuvarande värde. Sedan ökar den med ett steg
            CollectionName = collectionName;
            Description = description;
            Type = type;
            Owner = owner;
            CreateDate = DateTime.Now;
            Items = new List<CollectionItem>();
            IsStandard = isStandard;
        }

        // Lägger till en ny samling i listan collections
        public static void AddCollection(Collection collection)
        {
            collections.Add(collection);
        }

        // Sätter en användare till en fördefinierad samling
        public static void SetOwnerToStandardCollection(User user)
        {
            foreach (var collection in collections)
            {
                if (collection.IsStandard && collection.Owner == null)
                {
                    collection.Owner = user;
                }
            }
        }

        // Returnerar alla samlingar baserat på namn
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

        // Returnerar alla samlingar baserat på ID
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

        // Returnerar endast fördefinierade samlingar
        public static List<Collection> GetAllStandardCollections()
        {
            var standardCollection = new List<Collection>();

            foreach (var collection in collections)
            {
                if (collection.IsStandard)
                {
                    standardCollection.Add(collection);
                }
            }
            return standardCollection;
        }

        // Returnerar endast anpassade samlingar
        public static List<Collection> GetAllCustomCollections()
        {
            var customCollection = new List<Collection>();

            foreach (var collection in collections)
            {
                if (!collection.IsStandard)
                {
                    customCollection.Add(collection);
                }
            }
            return customCollection;
        }

        // Returnerar alla samlingar (anpassade och fördefinierade)
        public static List<Collection> GetAllCollections()
        {
            return collections;
        }

        // Uppdaterar namn och beskrivning för en samling baserat på namn
        public static void UpdateCollectionByName(string name, string newCollectionName, string newDescription)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionName == name)
                {
                    collection.CollectionName = newCollectionName;
                    collection.Description = newDescription;
                    break;
                }
            }
        }

        // Uppdaterar namn och beskrivning för en samling baserat på ID
        public static void UpdateCollectionById(int id, string newCollectionName, string newDescription)
        {
            foreach (Collection collection in collections)
            {
                if (collection.CollectionId == id)
                {
                    collection.CollectionName = newCollectionName;
                    collection.Description = newDescription;
                    break;
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

        // === Samlingsobjekt ===

        // Lägger till ett nytt samlingsobjekt till den aktuella samlingen
        public void AddItemToCollection(CollectionItem item)
        {
            Items.Add(item);
        }
    }
}