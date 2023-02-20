using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        ICategoryRepository _repository;
        ICategoryDomainService _domainSerive;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainSerive)
        {
            _repository = repository;
            _domainSerive = domainSerive;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();
            category.Edit(request.Title, request.Slug, request.SeoData, _domainSerive);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
