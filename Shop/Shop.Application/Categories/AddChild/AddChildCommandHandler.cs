using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCommandHandler : IBaseCommandHandler<AddChildCommand>
    {

        ICategoryRepository _repository;
        ICategoryDomainService _domainSerive;

        public AddChildCommandHandler(ICategoryRepository repository, ICategoryDomainService domainSerive)
        {
            _repository = repository;
            _domainSerive = domainSerive;
        }
        public async Task<OperationResult> Handle(AddChildCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult.NotFound();
            category.AddChild(request.Title, request.Slug, request.SeoData, _domainSerive);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
