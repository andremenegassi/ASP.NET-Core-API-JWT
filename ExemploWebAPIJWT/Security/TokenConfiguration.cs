using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploWebAPIJWT.Security
{
    public class TokenConfiguration
    {
        public string Audience { get; set; } //Para quem é Público
        public string Issuer { get; set; } //Emissor
        public int Seconds { get; set; }

    }
}
