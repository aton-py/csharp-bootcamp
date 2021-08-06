using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_api.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StingLength(100, MinimumLength = 3, ErrorMessage = "The name of the game must be at least {2} and at max {1} characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The name of the Studio must be at least {2} and at max {1} characters long.")]
        public string Studio { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "The price must be at least {2} $ and at max {1} $.")]
        public double Price { get; set; }
    }
}