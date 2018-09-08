namespace CoreOdata.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}