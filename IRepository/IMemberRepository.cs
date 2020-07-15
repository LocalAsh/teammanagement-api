using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementAngular.Models;

namespace TeamManagementAngular.IRepository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> Get();
        Task<Member> Get(string id);
        Task Add(Member Member);
        Task<string> Update(string id, Member Member);
    }
}
