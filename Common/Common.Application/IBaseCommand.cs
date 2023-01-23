using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application
{

    public interface IBaseCommand : IRequest<OperationResult>
    {
    }

    public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
    {
    }
}
