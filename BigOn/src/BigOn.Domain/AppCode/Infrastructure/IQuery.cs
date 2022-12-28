using MediatR;

namespace BigOn.Domain.AppCode.Infrastructure
{
    internal interface IQuery<T> : IRequest<T>
    {
    }

    internal interface ICommand<T> : IRequest<T>
    {



    }
}
