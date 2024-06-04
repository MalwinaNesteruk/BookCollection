using System.ComponentModel.DataAnnotations;

namespace BookCollection.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Tytuł' nie zostało uzupełnione")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole 'Imię autora' nie zostało uzupełnione")]
        public string NameAuthor { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwisko autora' nie zostało uzupełnione")]
        public string SurnameAuthor { get; set; }

        [Required(ErrorMessage = "Pole 'Gatunek literacki' nie zostało uzupełnione")]
        public string Genre { get; set; }

        [Range(1800, 2024, ErrorMessage = "W katalogu można zamieścić książki wydane między rokiem 1800 a 2024")]
        [Required(ErrorMessage = "Pole 'Data wydania' nie zostało uzupełnione")]
        public int? YearOfPublication { get ; set; }
    }
}
