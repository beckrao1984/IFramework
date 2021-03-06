﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace IFramework.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
       // where T : class, IEntity
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }


        public override Expression<Func<T, bool>> GetExpression()
        {
            //var body = Expression.OrElse(Left.GetExpression().Body, Right.GetExpression().Body);
            var body = Left.GetExpression().Or(Right.GetExpression());
            return Expression.Lambda<Func<T, bool>>(body, Left.GetExpression().Parameters);
        }
    }
}
