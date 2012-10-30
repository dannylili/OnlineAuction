using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace OnlineAuction.Business.BusinessRulesEngine.Common
{
    public interface IExpression
    {
        // object Evaluate(BusinessRulesContext context);
        Expression ToExpression(ParameterExpression parameter);
    }
}
