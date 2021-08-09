using Member.Data.Interface;
using Member.Data.Model;
using Member.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace member_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMembers members = new MembersRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Members>> GetAllMembers()
        {
            return members.GetAllMember();
        }
        [HttpGet]
        public ActionResult<Members> GetMemberById(int id)
        {
            return members.GetMember(id);
        }
    }
}