using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWeb.Models
{
    public class Model
    {
        public List<Book> Books { get; set; }
        public List<Journal> Journals { get; set; }
        public Model()
        {
            Books = new List<Book>();
            Journals = new List<Journal>();
        }
    }
}
