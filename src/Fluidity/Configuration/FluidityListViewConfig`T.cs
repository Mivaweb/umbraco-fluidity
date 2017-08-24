using System;
using System.Linq.Expressions;
using Fluidity.Actions;
using Fluidity.ListViewLayouts;

namespace Fluidity.Configuration
{
    public class FluidityListViewConfig<TEntityType> : FluidityListViewConfig
    {
        public FluidityListViewConfig(Action<FluidityListViewConfig<TEntityType>> config = null)
        {
            config?.Invoke(this);
        }

        public FluidityListViewConfig<TEntityType> AddBulkAction<TBulkActionType>()
            where TBulkActionType : FluidityBulkAction, new()
        {
            _bulkActions.Add(new TBulkActionType());
            return this;
        }

        public FluidityListViewConfig<TEntityType> SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public FluidityListViewFieldConfig<TEntityType, TValueType> AddField<TValueType>(Expression<Func<TEntityType, TValueType>> fieldExpression, Action<FluidityListViewFieldConfig<TEntityType, TValueType>> fieldConfig = null)
        {
            return AddField(new FluidityListViewFieldConfig<TEntityType, TValueType>(fieldExpression, fieldConfig));
        }

        public FluidityListViewFieldConfig<TEntityType, TValueType> AddField<TValueType>(FluidityListViewFieldConfig<TEntityType, TValueType> fieldConfig)
        {
            var field = fieldConfig;
            _fields.Add(field);
            return field;
        }

        public FluidityListViewConfig<TEntityType> AddLayout<TListViewLayoutType>()
            where TListViewLayoutType : FluidityListViewLayout, new()
        {
            _layouts.Add(new TListViewLayoutType());
            return this;
        }

        public FluidityListViewConfig<TEntityType> AddDataView(string name, Expression<Func<TEntityType, bool>> whereClause)
        {
            _dataViews.Add(new FluidityDataViewConfig(name, whereClause));
            return this;
        }
    }
}