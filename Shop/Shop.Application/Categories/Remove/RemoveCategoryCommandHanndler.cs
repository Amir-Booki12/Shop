using Common.Application;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories.Remove
{
    public class RemoveCategoryCommandHanndler : IBaseCommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHanndler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result =await _repository.removeCategory(request.CategoryId);
            if (result)
                return OperationResult.Success();

            return OperationResult.Error();

        }
    }
}
