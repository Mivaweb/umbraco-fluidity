using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fluidity.Configuration
{
    public abstract class FluidityListViewFieldConfig
    {
        protected PropertyInfo _property;
        internal PropertyInfo Property => _property;

        protected LambdaExpression _propertyExp;
        internal LambdaExpression PropertyExp => _propertyExp;

        protected string _heading;
        internal string Heading => _heading;

        protected Func<object, object, object> _format;
        internal Func<object, object, object> Format => _format;

        protected FluidityListViewFieldConfig(LambdaExpression propertyExp, PropertyInfo property)
        {
            _propertyExp = propertyExp;
            _property = property;
        }
    }
}