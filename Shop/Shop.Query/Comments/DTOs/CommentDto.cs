using Common.Query;
using Common.Query.Filter;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Comments.DTOs
{
    public class CommentDto:BaseDto
    {
        public long UserId { get;  set; }
        public long ProductId { get;  set; }
        public string ProductTitle { get;  set; }
        public string FullName { get;  set; }
        public string Text { get;  set; }
        public CommentStatus Status { get;  set; }
        public DateTime? CreationDate { get;  set; }
    }
    public class CommentFilterParams : BaseFilterParam
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CommentStatus? CommentStatus { get; set; }

    }
    public class CommentFilterResult : BaseFilter<CommentDto?, CommentFilterParams>
    {

    }

}
