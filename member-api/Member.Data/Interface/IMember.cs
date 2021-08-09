using System.Collections.Generic;
using Member.Data.Model;

namespace Member.Data.Interface
{
    public interface IMembers
    {
        List<Members> GetAllMember();
        Members GetMember(int id);
    }
}