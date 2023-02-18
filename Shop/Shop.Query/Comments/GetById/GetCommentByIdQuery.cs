using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Comments.GetById
{
    public record GetCommentByIdQuery(long CommentId):IQuery<CommentDto>;

    internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ShopContext _context;

        public GetCommentByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment =await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId);
         
           return comment.Map();
        }
    }
}
