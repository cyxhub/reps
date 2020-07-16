using GraphQL.Types;
using GraphqlPro.Models;
using GraphqlPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Schemas
{
    public class MovieSchema:ObjectGraphType<Movie>
    {
        public MovieSchema(ActorService actorService)
        {
            Name = "movie";
            Description = "";
            Field(x=>x.id);
            Field(x => x.name);
            Field(x => x.releaseDate);
            Field(x => x.actorid);
            Field<ActorType>("actor",resolve:context=> actorService.GetActor(context.Source.id));
            Field<StringGraphType>("cusString",resolve:context=>"uop");
        }
    }
}
