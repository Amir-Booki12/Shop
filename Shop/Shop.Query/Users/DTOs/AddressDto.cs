using Common.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.DTOs
{
    public class AddressDto:BaseDto
    {
        public long UserId { get;  set; }
        public string Shire { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get;  set; }
        public string PostAdress { get;  set; }
        public string NationalCode { get;  set; }
        public string Name { get;  set; }
        public string Family { get;  set; }
        [NotMapped]
        public string PhoneNumber { get;  set; }
        public bool AddressActive { get;  set; }

    }
}
