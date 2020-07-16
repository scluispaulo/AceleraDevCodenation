using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        public readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return (from ch in _context.Challenges
                    join ac in _context.Accelerations on ch.Id equals ac.ChallengeId
                    join ca in _context.Candidates on ac.Id equals ca.AccelerationId
                    where ca.UserId.Equals(userId) && ac.Id.Equals(accelerationId) 
                    select ch)
                    .Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            Models.Challenge resp;
            if(challenge.Id == 0)
            {
                resp = _context.Challenges.Add(challenge).Entity;
            } else
            {
                resp = _context.Challenges.Update(challenge).Entity;
            }
            _context.SaveChanges();
            return resp;
        }
    }
}