using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTest.Models
{
    //Model for Author table
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DoB { get; set; }
        //Contains BooksId for many-to-many
        public List<BookAuthor> BooksAuthors { get; set; }

    }
}
