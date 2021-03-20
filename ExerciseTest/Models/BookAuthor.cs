using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTest.Models
{
    //Model for Books and Authors foreign keys
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book;
        public int AuthorId { get; set; }
        public Author Author;
    }
}
