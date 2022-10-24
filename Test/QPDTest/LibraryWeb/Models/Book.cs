using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb.Models
{
    public class Book : Product
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public Book( string name, string author, string genre, int count, string publisher, int year) : base(name, count, publisher, year)
        {
            Author = author;
            Genre = genre;
        }
        public Book() : base()
        {
            Author = "";
            Genre = "";
        }
        public bool CompareTo(Book other)
        {
            return Name == other.Name && Author == other.Author && Genre == other.Genre && Publisher == other.Publisher && Year == other.Year;
        }
    }
}
