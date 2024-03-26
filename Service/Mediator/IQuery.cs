using MediatR;

public interface IQuery:IRequest{}

public interface IQuery<TResult>:IRequest<TResult>{}