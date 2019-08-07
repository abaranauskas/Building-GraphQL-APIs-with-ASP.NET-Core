using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.Api.Data.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        public string Review { get; set; }
    }
}
