using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_api.Exeptions
{
    public class GameNotFoundException : Exception
    {
        public GameAlreadyExistsException() : base("Game not found")
        { }
    }
}