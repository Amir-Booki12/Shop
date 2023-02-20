using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveImageProductCommand(long imageId,long ProductId):IBaseCommand;
}
