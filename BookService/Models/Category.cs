using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookService.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public bool Thriller { get; set; }
        public bool History { get; set; }
        public bool Drama { get; set; }
        public bool Biography { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Books.Categories))]
        public virtual Books Book { get; set; }
    }
}
