using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MemberRepository : IMemberRepository
    {
          private readonly MemberDbContext _context;
        public MemberRepository(MemberDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
         public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public int GetMemberIndividualPoints(int id)
        {
             return _context.Points.Where(x=>x.MemberId==id).Sum(s => s.point);
        }

        public IList<Member> GetMembers()
        {
            return  _context.Members.ToList();
        }

        public int GetMemberTeamPoints(int id)
        {
           return _context.Points.Where(x=>x.TeamLeadId==id).Sum(s => s.point);
        }

    }
}