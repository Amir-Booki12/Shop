using Common.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categoreis;
using Shop.Query.Categories.DTOs;
using System.Net.NetworkInformation;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
           var result = await _categoryFacade.GetAllCategories();
            return Ok(result);
        }

         [HttpGet("getChild/{parentId}")]
        public async Task<ActionResult<List<ChildCategoryDto>>> GetChildCategori(long parentId)
        {
           var result = await _categoryFacade.GetCategoryByParentId(parentId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoriById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            if (result.Status == OperationResultStatus.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("AddChild")]
        public async Task<IActionResult> AddChild(AddChildCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            if (result.Status == OperationResultStatus.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            if (result.Status == OperationResultStatus.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(long id)
        {
            var result = await _categoryFacade.Remove(id);
            if (result.Status == OperationResultStatus.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
