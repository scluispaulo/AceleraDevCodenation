using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        public readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from ac in _context.Accelerations
                    from su in _context.Submissions
                    where ac.Id.Equals(accelerationId) && su.ChallengeId.Equals(challengeId)
                    select su)
                    .Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions.Where(x => x.ChallengeId.Equals(challengeId)).Max(x => x.Score);
        }

        public Submission Save(Submission submission)
        {
            Submission resp;
            bool HasId = submission.ChallengeId > 0 && submission.UserId > 0;
            if (_context.Submissions.Any(x => 
                    x.UserId.Equals(submission.UserId) && x.ChallengeId.Equals(submission.ChallengeId)))
            {
                resp = _context.Submissions.Update(submission).Entity;
            } else
            {
                resp = _context.Submissions.Add(submission).Entity;
            }
            _context.SaveChanges();
            return resp;
        }
    }
}
