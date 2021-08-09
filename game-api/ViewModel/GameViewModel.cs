using System;

namespace game_api.ViewModel
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Studio { get; set; }
    }
}