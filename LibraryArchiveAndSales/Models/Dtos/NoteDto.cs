namespace LibraryArchiveAndSales.Models.Dtos
{
    public class NoteDto
    {
        public int BookId { get; set; }
        public string Content { get; set; }
        public bool IsShared { get; set; }
    }
}
