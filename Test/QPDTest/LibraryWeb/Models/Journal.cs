using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb.Models
{
    public class Journal : Product
    {
        public int Periodically { get; set; }
        public int Number { get; set; }
        public Journal(string name, int count, string publisher, int year, int periodically, int number): base(name, count, publisher, year)
        {
            Periodically = periodically;
            Number = number;
        }
        public Journal() : base()
        {
            Periodically = 0;
            Number = 0;
        }
        public bool CompareTo(Journal other)
        {
            return Name == other.Name && Publisher == other.Publisher && Year == other.Year && Periodically == other.Periodically && Number == other.Number;
        }
    }
}
