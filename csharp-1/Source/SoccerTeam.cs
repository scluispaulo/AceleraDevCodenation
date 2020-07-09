using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class SoccerTeam
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CorUniformePrincipal { get; set; }
        public string CorUniformeSecundario { get; set; }
        public long Capitain { get; set; }
    }
}