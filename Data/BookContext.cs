using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBookApi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Data
{
    public class BookContext:IdentityDbContext<ApplicationUser>
    {
        public BookContext(DbContextOptions<BookContext> options)
            :base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
