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
        #nullable enable
        public bool ok { get; set; }
        public AuthResponsePlayerDto? player { get; set; }
        #nullable disable
    }

    [Serializable]
    public class AuthResponsePlayerDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool online { get; set; }
        public string photo { get; set; }
        public bool indications { get; set; }
    }
}
