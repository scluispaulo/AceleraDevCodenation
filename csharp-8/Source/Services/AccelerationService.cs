using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        public readonly CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return (from ca in _context.Candidates
                    join ac in _context.Accelerations on ca.AccelerationId equals ac.Id
                    where ca.CompanyId.Equals(companyId)
                    select ac)
                    .Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            Acceleration resp;
            if (acceleration.Id == 0){
                resp = _context.Accelerations.Add(acceleration).Entity;
            } else {
                resp = _context.Accelerations.Update(acceleration).Entity;
            }
            _context.SaveChanges();
            return resp;
        }
    }
}
