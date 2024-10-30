namespace TheCollectorApp
{
    public class Collection
    {
        public int CollectionId { get; }// ID ska endast finnas på egna skapta samlingar och får ej ändras
        public string Name { get; set; }
        public string Description { get; set; }
        public CollectionType Type { get; } // Olika typer av färdiga samlingar att välja mellan
        public List<CollectionItem> Items { get; set; }
        public DateTime CreateDate { get; }
        public User Owner { get; }

        //Lista för alla samlingar
        private static List<Collection> collections = new List<Collection>();

        public Collection(string name, string description, CollectionType type, User owner)
        {
            Name = name;
            Description = description;
            Type = type;
            Owner = owner;
            CreateDate = DateTime.Now;
            Items = new List<CollectionItem>();
        }

        // CRUD metoder. Endast egna samlingar

        // Create
        // Read
        // Update
        // Delete
    }
}