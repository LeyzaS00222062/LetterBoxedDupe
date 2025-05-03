using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterBoxedDuped_WPF
{
    public class ReviewDbContent : DbContext
    {
        public DbSet<Reviews> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "reviews.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

        }
    }
}
