namespace LibraryArchiveAndSales.Models.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Content { get; set; }
        public bool IsShared { get; set; }

        public Book Book { get; set; }
    }
}
