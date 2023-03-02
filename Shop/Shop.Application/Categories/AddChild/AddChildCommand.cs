using Commom.Domain.ValueObjects;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCommand(long ParentId,string Title, string Slug, SeoData SeoData)
        :IBaseCommand<long>;
}
