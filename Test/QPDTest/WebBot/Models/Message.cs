using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBot.Models
{
    public class Message
    {
        public Message()
        {
            _Message = ""; 
        }
        public int id { get; set; }
        public string _Message { get; set; }
    }
}
