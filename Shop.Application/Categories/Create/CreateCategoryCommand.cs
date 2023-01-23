using Commom.Domain.ValueObjects;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public record CreateCategoryCommand(string Title,string Slug,SeoData SeoData) :IBaseCommand;
     
}
