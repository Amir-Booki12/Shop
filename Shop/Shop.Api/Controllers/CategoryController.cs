using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categoreis;
using Shop.Query.Categories.DTOs;
using System.Net;
using System.Net.NetworkInformation;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiController
    {
       private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
           var result = await _categoryFacade.GetAllCategories();
            return QueryResult(result);
        }

         [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetChildCategori(long parentId)
        {
           var result = await _categoryFacade.GetCategoryByParentId(parentId);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoriById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> CreateCategory(AddChildCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> RemoveCategory(long id)
        {
            var result = await _categoryFacade.Remove(id);
            return CommandResult(result);
        }
    }
}
