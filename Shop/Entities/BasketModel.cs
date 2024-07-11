using SQLite;

namespace Shop.Entities
{
    public class BasketModel
    {
        [PrimaryKey] public int Id { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }
}
