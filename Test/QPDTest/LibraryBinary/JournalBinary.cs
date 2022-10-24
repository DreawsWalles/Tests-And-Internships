using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryBinary
{
    class JournalBinary : Product
    {

        public int Periodically { get; set; }
        public int Number { get; set; }
        public JournalBinary(int code, string name, int count, string publisher, int year, int periodically, int number) : base(code, name, count, publisher, year)
        {
            Periodically = periodically;
            Number = number;
        }
        public JournalBinary() : base()
        {
            Periodically = 0;
            Number = 0;
        }
        public override string ToString()
        {
            return $"Код журнала: {Code}\r\nНазвание журнала: {Name}\r\nИздательство: {Publisher}\r\nГод: {Year}\r\nКоличество: {Count}\r\nПериодичность: {Periodically}\r\nНомер: {Number}";
        }
        public bool CompareTo(JournalBinary other)
        {
            return Code == other.Code && Name == other.Name && Publisher == other.Publisher && Year == other.Year && Periodically == other.Periodically && Number == other.Number;
        }
        public bool Write(BinaryWriter file)
        {
            try
            {
                file.Write(Code);
                file.Write(Name);
                file.Write(Count);
                file.Write(Publisher);
                file.Write(Year);
                file.Write(Periodically);
                file.Write(Number);
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
                Count = file.ReadInt32();
                Publisher = file.ReadString();
                Year = file.ReadInt32();
                Periodically = file.ReadInt32();
                Number = file.ReadInt32();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
