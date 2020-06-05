using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
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

        [System.Obsolete]
        public int GetMemberTeamPoints(int memberid,int TeamLeadId)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@MemberId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value =memberid
                        },
                          new SqlParameter() {
                            ParameterName = "@TeamLeadId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value =TeamLeadId
                        },
                        new SqlParameter() {
                            ParameterName = "@TeamPoints",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Output,
                        }};
        int affectedRows=_context.Database.ExecuteSqlCommand("[dbo].[Sp_getTotalPoints] @MemberId,@TeamLeadId, @TeamPoints out", param);
        int teamPoints = Convert.ToInt32(param[2].Value); 
        return teamPoints;
        }

    }
}