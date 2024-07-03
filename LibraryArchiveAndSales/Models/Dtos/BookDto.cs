namespace LibraryArchiveAndSales.Models.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ShelfLocation { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
