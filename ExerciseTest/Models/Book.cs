using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTest.Models
{
    //Model for Book table
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Edition { get; set; }
        [Column(TypeName = "date")]
        public DateTime Publeshid_At { get; set; }
        //Contains AuthorsId for many-to-many
        public List<BookAuthor> BooksAuthors { get; set; }
    }
}
