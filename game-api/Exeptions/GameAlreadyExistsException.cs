using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_api.Exeptions
{
    public class GameAlreadyExistsException : Exception
    {
        public GameAlreadyExistsException() : base("This game already existis")
        { }
    }
}