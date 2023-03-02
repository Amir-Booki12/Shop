using Common.Application;
using Shop.Application.Categories.Create;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

public class CreateCategoryCommandHanlder : IBaseCommandHandler<CreateCategoryCommand,long>
{
    ICategoryRepository _repository;
    ICategoryDomainService _domainSerive;

    public CreateCategoryCommandHanlder(ICategoryRepository repository, ICategoryDomainService domainSerive)
    {
        _repository = repository;
        _domainSerive = domainSerive;
    }

    public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Title,request.Slug,request.SeoData,_domainSerive);
        _repository.Add(category);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);
    }
}