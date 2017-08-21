using System;
using System.Linq.Expressions;
using Fluidity.DataViews;
using Fluidity.ListViewLayouts;

namespace Fluidity.Configuration
{
    public class FluidityListViewConfig<TEntityType> : FluidityListViewConfig
    {
        public FluidityListViewConfig(Action<FluidityListViewConfig<TEntityType>> config = null)
        {
            config?.Invoke(this);
        }

        public FluidityListViewConfig<TEntityType> AddMenuAction<TActionType>()
            where TActionType : IFluidityMenuAction, new()
        {
            _menuActions.Add(new TActionType());
            return this;
        }

        public FluidityListViewConfig<TEntityType> AddFilter<TFilterType>()
            where TFilterType : IFluidityFilter, new()
        {
            _filters.Add(new TFilterType());
            return this;
        }

        public FluidityListViewConfig<TEntityType> AddBulkAction<TBulkActionType>()
            where TBulkActionType : IFluidityBulkAction, new()
        {
            _bulkActions.Add(new TBulkActionType());
            return this;
        }

        public FluidityListViewConfig<TEntityType> SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public FluidityListViewConfig<TEntityType> SetNameFormat(Func<TEntityType, string> format)
        {
            _nameFormat = (entity) => format((TEntityType)entity);
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

        public FluidityListViewConfig<TEntityType> AddSearchField(Expression<Func<TEntityType, string>> fieldExpression)
        {
            return AddSearchField(new FluidityListViewSearchFieldConfig<TEntityType>(fieldExpression));
        }

        public FluidityListViewConfig<TEntityType> AddSearchField(FluidityListViewSearchFieldConfig<TEntityType> fieldConfig)
        {
            var field = fieldConfig;
            _searchFields.Add(field);
            return this;
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