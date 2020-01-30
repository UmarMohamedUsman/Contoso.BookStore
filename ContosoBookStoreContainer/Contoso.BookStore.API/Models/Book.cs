using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.BookStore.API.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        [MaxLength(35)]
        public string Author { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
