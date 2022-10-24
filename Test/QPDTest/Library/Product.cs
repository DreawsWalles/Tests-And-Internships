using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Publisher { get; set; }
        public int Year { get;  set; }
        public Product(int code, string name, int count, string publisher, int year)
        {
            Code = code;
            Name = name;
            Count = count;
            Publisher = publisher;
            Year = year; 
        }
        public Product() : this(0, "", 0, "", 0)
        {

        }
        public bool CompareTo(Product other)
        {
            return Name == other.Name;
        }
        public void IncCount(int cnt = 1) => Count += cnt;
        public void DecCount(int cnt = 1) => Count = Count - cnt < 0 ? 0 : Count - cnt;
    }
}
