using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWeb.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
