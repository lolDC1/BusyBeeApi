using System.Linq.Expressions;

namespace BusyBee.Persistence.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, TResult>> AndAlso<T, TResult>(
        this Expression<Func<T, TResult>> expr1,
        Expression<Func<T, TResult>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<T, TResult>>(
            Expression.AndAlso(left!, right!),
            parameter);
    }

    public static Expression<Func<T, TResult>> OrElse<T, TResult>(
        this Expression<Func<T, TResult>> expr1,
        Expression<Func<T, TResult>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<T, TResult>>(
            Expression.OrElse(left!, right!),
            parameter);
    }

    public static Expression<Func<T, TResult>> ChainOrElse<T, TInput, TResult>(this Func<TInput, Expression<Func<T, TResult>>>
            expression,
        ICollection<TInput> data)
    {
        var expr = expression.Invoke(data.First());
        expr = data.Skip(1).Aggregate(expr, (accum, id) => accum.OrElse(expression.Invoke(id)));
        return expr;
    }


    private class ReplaceExpressionVisitor
        : ExpressionVisitor
    {
        private readonly Expression _newValue;
        private readonly Expression _oldValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression? Visit(Expression? node)
        {
            return node == _oldValue ? _newValue : base.Visit(node);
        }
    }
}