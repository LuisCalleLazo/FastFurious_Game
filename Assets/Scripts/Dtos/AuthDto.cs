using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFurios_Game.Dtos
{
    [Serializable]
    public class AuthResponseDto
    {
        public string CurrentToken {get; set;}
        public string RefreshToken {get; set;}
        public PlayerDto Player { get; set; }
    }

    [Serializable]
    public class PlayerDto
    {
        public int Id {get; set;}
        public string Name {get; set;} 
        public string Email { get; set; }
        public int Age {get; set;}
    }
}
