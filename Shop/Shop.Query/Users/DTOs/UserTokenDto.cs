using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.DTOs
{
    public class UserTokenDto:BaseDto
    {
        public long UserId { get;  set; }
        public string HashJwtToken { get;  set; }
        public string HashJwtRefreshToken { get;  set; }
        public DateTime ExpireDateToken { get;  set; }
        public DateTime ExpireDateRefreshToken { get;  set; }
        public string Device { get;  set; }

    }
}
