using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Publisher { get; set; }
        public int Year { get;  set; }
        public Product( string name, int count, string publisher, int year)
        {
            Name = name;
            Count = count;
            Publisher = publisher;
            Year = year; 
        }
        public Product() : this("", 0, "", 0)
        {

        }
        public bool CompareTo(Product other)
        {
            return Name == other.Name;
        }
    }
}
