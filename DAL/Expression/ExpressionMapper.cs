﻿using System.Linq.Expressions;
using System.Linq;
using System;

namespace DAL.Interface
{
    public class ExpressionMapper<TFrom, TO, TResult>
    {
        private class Visitor<TFrom, TTo> : ExpressionVisitor
        {
            public ParameterExpression ParameterExpression { get; private set; }

            public Visitor(ParameterExpression parameterExpression)
            {
                ParameterExpression = parameterExpression;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ParameterExpression;
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == typeof(TFrom))
                {
                    return Expression.MakeMemberAccess(Visit(node.Expression), typeof(TTo).GetMember(node.Member.Name).FirstOrDefault());
                }
                return base.VisitMember(node);
            }
        }

        public static Expression<Func<TO, TResult>> Map(Expression<Func<TFrom, TResult>> expression)
        {
            Visitor<TFrom, TO> expressionMapper = new Visitor<TFrom, TO>(Expression.Parameter(typeof(TO), expression.Parameters[0].Name));
            return Expression.Lambda<Func<TO, TResult>>(expressionMapper.Visit(expression.Body), expressionMapper.ParameterExpression);
        }
    }
}