using System.Net;
using MediatR;

public interface ICommand:IRequest{
    
}

public interface ICommand<TResult>:IRequest<TResult>{}