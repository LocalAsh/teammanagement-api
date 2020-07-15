

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementAngular.DbModels;
using TeamManagementAngular.IRepository;
using TeamManagementAngular.Models;

namespace TeamManagementAngular.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ObjectContext _context = null;

        public MemberRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Member member)
        {
            await _context.Members.InsertOneAsync(member);
        }

        public async Task<IEnumerable<Member>> Get()
        {
            return await _context.Members.Find(x => true).ToListAsync();
        }

        public async Task<Member> Get(string id)
        {
            var member = Builders<Member>.Filter.Eq("Id", id);
            return await _context.Members.Find(member).FirstOrDefaultAsync();
        }

        public async Task<string> Update(string id, Member member)
        {
            await _context.Members.ReplaceOneAsync(z => z.Id == id, member);
            return "";
        }
    }
}