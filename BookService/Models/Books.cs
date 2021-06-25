using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Models
{
    public class Books
    {
            [Key]
            public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime Registration { get; set; }
        public Category Categories { get; set; }
        public string Description { get; set; }

            //[InverseProperty("Book")]
            //public virtual ICollection<Category> Categories { get; set; }
    }
}
