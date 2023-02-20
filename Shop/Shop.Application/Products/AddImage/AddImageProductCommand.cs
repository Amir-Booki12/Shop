using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Application.Products.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.AddImage
{
    internal class AddImageProductCommand:IBaseCommand
    {
        public AddImageProductCommand(long productId, int sequence, IFormFile imageFile)
        {
            ProductId = productId;

            Sequence = sequence;
            ImageFile = imageFile;
        }

        public long ProductId { get; internal set; }
        public  IFormFile ImageFile { get; internal set; }
        public int Sequence { get; private set; }
    }
}
