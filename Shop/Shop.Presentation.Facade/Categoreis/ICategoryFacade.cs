using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Categoreis
{
    public interface ICategoryFacade
    {
        Task<OperationResult<long>> AddChild(AddChildCommand command);
        Task<OperationResult<long>> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult> Remove(long id);


        Task<CategoryDto> GetCategoryById(long id);
        Task<List<ChildCategoryDto>> GetCategoryByParentId(long parentId);
        Task<List<CategoryDto>> GetAllCategories();
    }
}
