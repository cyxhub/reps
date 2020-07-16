using GraphQL.Types;
using GraphqlPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Schemas
{
    public class ActorType:ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x=>x.id);
            Field(x => x.name);
        }
    }
}
