using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class Product
    {
        public Product() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}