namespace BookCollection.Models
{
    public class BookAndBookList
    {
        public Book OneBook { get; set; }
        public IEnumerable<Book> ListOfBooks {  get; set; } =new List<Book>();
    }
}
