namespace LibraryArchiveAndSales.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ShelfLocation { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
