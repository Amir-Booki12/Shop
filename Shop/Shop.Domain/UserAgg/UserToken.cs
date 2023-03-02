using Commom.Domain;
using Commom.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class UserToken:BaseEntity
    {
        public UserToken(string hashJwtToken, string hashJwtRefreshToken, 
            DateTime expireDateToken, DateTime expireDateRefreshToken, string device)
        {
            HashJwtToken = hashJwtToken;
            HashJwtRefreshToken = hashJwtRefreshToken;
            ExpireDateToken = expireDateToken;
            ExpireDateRefreshToken = expireDateRefreshToken;
            Device = device;
            Gourd();
        }

        public long UserId { get; internal set; }
        public string HashJwtToken { get; private set; }
        public string HashJwtRefreshToken { get; private set; }
        public DateTime ExpireDateToken { get; private set; }
        public DateTime ExpireDateRefreshToken { get; private set; }
        public string Device { get; private set; }



        public void Gourd()
        {
            NullOrEmptyDomainDataException.CheckString(HashJwtToken, nameof(HashJwtToken));
            NullOrEmptyDomainDataException.CheckString(HashJwtRefreshToken, nameof(HashJwtRefreshToken));

            if (ExpireDateToken < DateTime.Now)
                throw new InvalidDomainDataException("Invalid ExpireDateToken");

            if (ExpireDateRefreshToken < ExpireDateToken)
                throw new InvalidDomainDataException("Invalid ExpireDateRefreshToken");
        }
    }

    
}
