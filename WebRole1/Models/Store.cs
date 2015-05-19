using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}