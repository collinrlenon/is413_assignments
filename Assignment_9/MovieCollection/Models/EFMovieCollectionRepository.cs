using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class EFMovieCollectionRepository : IMovieCollectionRepository
    {
        private MovieCollectionDBContext _context;

        //Constructor
        public EFMovieCollectionRepository(MovieCollectionDBContext context)
        {
            _context = context;
        }
        public IQueryable<Movies> Movies => _context.Movies;
    }
}
