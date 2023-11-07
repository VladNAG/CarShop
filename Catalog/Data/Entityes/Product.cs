namespace Catalog.Data.Entityes
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? img { get; set; }

        public string? shortDesc { get; set; }

        public string? longDesc { get; set; }

        public ushort Price { get; set; }

        public Category Category { get; set; }
    }
}
