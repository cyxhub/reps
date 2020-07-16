using GraphqlPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Services
{
    public class MovieService
    {
        public IEnumerable<Movie> movies;
        public MovieService()
        {
            movies = new List<Movie>
            {
                new Movie{id=10, name="oier", releaseDate=DateTime.Now, actorid=1},
                new Movie{id=20, name="sdf", releaseDate=DateTime.Now, actorid=2},
                new Movie{id=30, name="rgr", releaseDate=DateTime.Now, actorid=3},
            };
        }
        public Movie GetMoviebyid(int id)
        {
            return movies.SingleOrDefault(x=>x.id==id);
        }
        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }
    }
}
