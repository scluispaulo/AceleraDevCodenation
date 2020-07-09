using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class SoccerPlayer
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }
    }
}