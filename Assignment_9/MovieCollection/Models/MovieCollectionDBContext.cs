using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieCollectionDBContext : DbContext
    {
        public MovieCollectionDBContext(DbContextOptions<MovieCollectionDBContext> options) : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
    }
}
