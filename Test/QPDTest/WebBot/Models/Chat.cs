using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBot.Models
{
    public class Chat : DbContext
    {
        public DbSet<Message> dialogs { get; set; }
        public Chat(DbContextOptions<Chat> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
