using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase
{
    public class Journal : Product
    {
        public int Periodically { get; set; }
        public int Number { get; set; }
        public Journal(int code, string name, int count, string publisher, int year, int periodically, int number) : base(code, name, count, publisher, year)
        {
            Periodically = periodically;
            Number = number;
        }
        public Journal() : base()
        {
            Periodically = 0;
            Number = 0;
        }
        public override string ToString()
        {
            return $"Код журнала: {Code}\r\nНазвание журнала: {Name}\r\nИздательство: {Publisher}\r\nГод: {Year}\r\nКоличество: {Count}\r\n Периодичность: {Periodically}\r\nНомер: {Number}";
        }
        public bool CompareTo(Journal other)
        {
            return Name == other.Name && Publisher == other.Publisher && Year == other.Year && Periodically == other.Periodically && Number == other.Number;
        }
    }
}
