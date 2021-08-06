using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_api.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Studio { get; set; }

    }
}