using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        public readonly CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates.Where(x => x.AccelerationId.Equals(accelerationId)).Distinct().ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates.Where(x => x.CompanyId.Equals(companyId)).Distinct().ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates
                        .Where(x => x.AccelerationId.Equals(accelerationId)
                                && x.UserId.Equals(userId) && x.CompanyId.Equals(companyId))
                        .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate resp;
            bool HasId = candidate.UserId > 0 && candidate.AccelerationId > 0 && candidate.CompanyId > 0;
            if(HasId && _context.Candidates.Any(x => x.UserId.Equals(candidate.UserId) 
                                                    && x.AccelerationId.Equals(candidate.AccelerationId) 
                                                    && x.CompanyId.Equals(candidate.CompanyId)))
            {
                    resp = _context.Candidates.Update(candidate).Entity;
            } else 
            {
                resp = _context.Candidates.Add(candidate).Entity;
            }

            _context.SaveChanges();
            return resp;
        }
    }
}
