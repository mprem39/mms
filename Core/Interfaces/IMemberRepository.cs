using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMemberRepository
    {
         void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        IList<Member> GetMembers();
        int GetMemberIndividualPoints(int id);
        int GetMemberTeamPoints(int mid,int tid);

    }
}