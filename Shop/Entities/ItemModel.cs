using SQLite;

namespace Shop.Entities
{
    public class ItemModel
    {
        [PrimaryKey] public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

    }
}
