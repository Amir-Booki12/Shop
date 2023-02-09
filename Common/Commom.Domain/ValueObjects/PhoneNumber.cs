using Commom.Domain.Exceptions;
using Commom.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commom.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
            Value = value;
        }

        public string Value { get; private set; }
    }

}
