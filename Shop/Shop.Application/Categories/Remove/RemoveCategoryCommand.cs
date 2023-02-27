using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Remove
{
    public record RemoveCategoryCommand(long CategoryId):IBaseCommand;
}
