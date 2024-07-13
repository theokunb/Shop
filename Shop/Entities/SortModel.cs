using SQLite;

namespace Shop.Entities
{
    public class SortModel
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
    }
}
