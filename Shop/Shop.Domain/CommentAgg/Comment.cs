using Commom.Domain;
using Commom.Domain.Exceptions;
using Shop.Domain.CommentAgg.Enums;
using Shop.Domain.ProductAgg;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Domain.CommentAgg
{
    public class Comment:AggregateRoot
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Text { get; private set; }
        public CommentStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public Comment(long userId, long productId, string text)
        {
            UserId = userId;
            ProductId = productId;
            Text = text;
        }

        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
            LastUpdate = DateTime.Now;
            Text = text;
        }
        public void ChengeStatus(CommentStatus status)
        {
            LastUpdate = DateTime.Now;
            Status = Status;
        }
    }


}
