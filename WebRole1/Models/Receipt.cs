using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebRole1.Models
{
    public class Receipt
    {
        public Receipt() { }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
