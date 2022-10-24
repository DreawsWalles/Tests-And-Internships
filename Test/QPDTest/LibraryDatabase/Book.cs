using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase
{
    public class Book : Product
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public Book(int code, string name, string author, string genre, int count, string publisher, int year) : base(code, name, count, publisher, year)
        {
            Author = author;
            Genre = genre;
        }
        public Book() : base()
        {
            Author = "";
            Genre = "";
        }
        public override string ToString()
        {
            return $"Код книги: {Code}\r\nНазвание книги: {Name}\r\nАвтор: {Author}\r\nЖанр: {Genre}\r\nИздательство: {Publisher}\r\nГод: {Year}\r\nКоличество: {Count}";
        }
        public bool CompareTo(Book other)
        {
            return Name == other.Name && Author == other.Author && Genre == other.Genre && Publisher == other.Publisher && Year == other.Year;
        }
    }
}
