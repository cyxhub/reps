using GraphqlPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlPro.Services
{
    public class ActorService
    {
        public IEnumerable<Actor> actors;
        public ActorService()
        {
            actors = new List<Actor>
            {
                new Actor{id=1,name="oei"},
                new Actor{id=2,name="oerti"},
                new Actor{id=3,name="safi"},
            };
        }
        public Actor GetActor(int id)
        {
            return actors.SingleOrDefault(x=>x.id==id);
        }
        public IEnumerable<Actor> GetActors()
        {
            return actors;
        }
    }
}
