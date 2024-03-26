using MediatR;

public interface IQueryHandler<TCommand>:IRequestHandler<TCommand> 
where TCommand :IQuery{}

public interface IQueryHandler<TCommand,TResult>:IRequestHandler<TCommand,TResult> 
where TCommand :IQuery<TResult> {}