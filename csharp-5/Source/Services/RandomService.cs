using System;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {
        private readonly Random _rand = new Random();
        public int RandomInteger(int max)
        {
            return _rand.Next(max);
        }
    }
}