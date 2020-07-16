using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        public readonly CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return (from ac in _context.Accelerations
                    join ca in _context.Candidates on ac.Id equals ca.AccelerationId
                    join us in _context.Users on ca.UserId equals us.Id
                    where ac.Name.Equals(name)
                    select us)
                    .Distinct().ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return (from ca in _context.Candidates
                    join us in _context.Users on ca.UserId equals us.Id
                    where ca.CompanyId.Equals(companyId)
                    select us)
                    .Distinct().ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public User Save(User user)
        {
            User resp;
            if (user.Id == 0)
            {
                resp = _context.Users.Add(user).Entity;
            } else 
            {
                resp = _context.Users.Update(user).Entity;
            }
            _context.SaveChanges();
            return resp;
        }
    }
}
