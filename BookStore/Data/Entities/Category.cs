using BookStore.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int InsertedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public List<Book> Books { get; set; }
    }
}
