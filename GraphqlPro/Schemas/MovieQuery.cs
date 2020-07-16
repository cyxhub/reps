using GraphQL.Types;
using GraphqlPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Schemas
{
    public class MovieQuery:ObjectGraphType
    {
        public MovieQuery(MovieService movieService)
        {
            Name = "query";
            Field<ListGraphType<MovieSchema>>("movie",resolve:context=>movieService.GetMovies());
        }
    }
}
