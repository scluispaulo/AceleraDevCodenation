using System;

namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym, double area = 0)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.Area = area;
        }

        public string Name { get; set; }
        public string Acronym { get; set; }
        public double Area { get; set; }

    }

}
