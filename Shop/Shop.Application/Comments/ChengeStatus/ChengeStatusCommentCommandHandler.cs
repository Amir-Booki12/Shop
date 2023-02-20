using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChengeStatus
{
    public class ChengeStatusCommentCommandHandler : IBaseCommandHandler<ChengeStatusCommentCommand>
    {

        ICommentRepository _repository;

        public ChengeStatusCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChengeStatusCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =await _repository.GetTracking(request.Id);
            if (comment == null)
                return OperationResult.NotFound();
            comment.ChengeStatus(request.Status);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
