using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryBinary
{
    class BookBinary : Product
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public BookBinary(int code, string name, string author, string genre, int count, string publisher, int year) : base(code, name, count, publisher, year)
        {
            Author = author;
            Genre = genre;
        }
        public BookBinary() : base()
        {
            Author = "";
            Genre = "";
        }
        public override string ToString()
        {
            return $"Код книги: {Code}\r\nНазвание книги: {Name}\r\nАвтор: {Author}\r\nЖанр: {Genre}\r\nИздательство: {Publisher}\r\nГод: {Year}\r\nКоличество: {Count}";
        }
        public bool CompareTo(BookBinary other)
        {
            return Code == other.Code && Name == other.Name && Author == other.Author && Genre == other.Genre && Publisher == other.Publisher && Year == other.Year;
        }
        public bool Write(BinaryWriter file)
        {
            try
            {
                file.Write(Code);
                file.Write(Name);
                file.Write(Author);
                file.Write(Genre);
                file.Write(Count);
                file.Write(Publisher);
                file.Write(Year);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Read(BinaryReader file)
        {
            try
            {
                Code = file.ReadInt32();
                Name = file.ReadString();
                Author = file.ReadString();
                Genre = file.ReadString();
                Count = file.ReadInt32();
                Publisher = file.ReadString();
                Year = file.ReadInt32();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
