using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GetAllCategory;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParentId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Categoreis
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;

        public CategoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult<long>> AddChild(AddChildCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _mediator.Send(new GetListCategoryQuery());
        }

        public async Task<CategoryDto> GetCategoryById(long id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
        }

        public async Task<List<ChildCategoryDto>> GetCategoryByParentId(long parentId)
        {
            return await _mediator.Send(new GetCategoryByParentIIdQuery(parentId));
        }

        public async Task<OperationResult> Remove(long id)
        {
            return await _mediator.Send(new RemoveCategoryCommand(id));
        }
    }
}
