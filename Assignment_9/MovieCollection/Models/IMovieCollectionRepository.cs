using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public interface IMovieCollectionRepository
    {
        IQueryable<Movies> Movies { get; }
    }
}
