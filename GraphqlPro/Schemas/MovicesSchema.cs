using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Schemas
{
    public class MovicesSchema:Schema
    {
        public MovicesSchema(IDependencyResolver dependencyResolver,MovieQuery movieQuery)
        {
            DependencyResolver = dependencyResolver;
            Query = movieQuery;
        }
    }
}
