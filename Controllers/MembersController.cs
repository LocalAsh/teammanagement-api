using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using System.Threading.Tasks;
using TeamManagementAngular.IRepository;
using Newtonsoft.Json;
using TeamManagementAngular.Models;
using Microsoft.AspNetCore.Cors;

namespace TeamManagementAngular.Controllers
{
    [Route("api/[controller]")]
    public class MembersController
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetMember();
        }

        private async Task<string> GetMember()
        {
            var members = await _memberRepository.Get();
            return Newtonsoft.Json.JsonConvert.SerializeObject(members);
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetMemberById(id);
        }

        private async Task<string> GetMemberById(string id)
        {
            var member = await _memberRepository.Get(id) ?? new Member();
            return Newtonsoft.Json.JsonConvert.SerializeObject(member);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task<string> Post([FromBody] Member member)
        {
            await _memberRepository.Add(member);
            return "";
        }

        [EnableCors("AllowOrigin")]
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Member member)
        {
            if (string.IsNullOrEmpty(id)) return "Id provided is invalid!";
            return await _memberRepository.Update(id, member);
        }
    }
}
