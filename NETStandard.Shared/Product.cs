using System;
using System.Collections.Generic;
using System.Text;

namespace NETStandard.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name}, {Price}";
        }
    }
}
