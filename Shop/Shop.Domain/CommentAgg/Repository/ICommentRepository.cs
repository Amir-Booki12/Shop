using Commom.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CommentAgg.Repository
{
    public interface ICommentRepository:IBaseRepository<Comment>
    {  
            Task DeleteAndSave(Comment comment);      
    }
}
