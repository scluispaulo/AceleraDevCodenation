using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        public readonly CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return (from ca in _context.Candidates
                    join co in _context.Companies on ca.CompanyId equals co.Id
                    where ca.AccelerationId.Equals(accelerationId)
                    select co)
                    .Distinct().ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IList<Company> FindByUserId(int userId)
        {
            return (from ca in _context.Candidates
                    join co in _context.Companies on ca.CompanyId equals co.Id
                    where ca.UserId.Equals(userId)
                    select co)
                    .Distinct().ToList();
        }

        public Company Save(Company company)
        {
            Company resp;
            if (company.Id == 0)
            {
                resp = _context.Companies.Add(company).Entity;
            } else
            {
                resp = _context.Companies.Update(company).Entity;
            }
            _context.SaveChanges();
            return resp;
        }
    }
}