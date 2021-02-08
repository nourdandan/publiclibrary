using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicLibrary.Models
{
    public class Form
    {
        public int Id { get; set; }

        [Display(Name = "Book Name")]
        [StringLength(50, ErrorMessage = errorStringLengthMessage)]
        [Required]
        public string  BookName { get; set; }

        [Display(Name = "Author Name")]
        [StringLength(40 , ErrorMessage = errorStringLengthMessage)]
        [Required]
        public string  AuthorName { get; set; }

        [StringLength(500 , ErrorMessage = errorStringLengthMessage)]
        [Required]
        public string Question { get; set; }

        [NotMapped]
        private const string errorStringLengthMessage = "{0} length can't be more than {1}.";
    }
}
