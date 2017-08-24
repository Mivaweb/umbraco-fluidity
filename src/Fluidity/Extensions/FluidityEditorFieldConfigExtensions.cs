﻿using System;
using Fluidity.Configuration;

namespace Fluidity.Extensions
{
    internal static class FluidityEditorFieldConfigExtensions
    {
        internal static int GetOrCalculateDefinititionId(this FluidityEditorFieldConfig fieldConfig)
        {
            if (fieldConfig.DataTypeId > 0)
                return fieldConfig.DataTypeId;

            var dtdId = -88; // Text string (default)

            // TODO: Check for NText attribute for textarea/rte?

            if (fieldConfig.Property.PropertyInfo.PropertyType == typeof(DateTime)
                || fieldConfig.Property.PropertyInfo.PropertyType == typeof(DateTime?))
            {
                dtdId = -41; // Date picker
            }

            if (fieldConfig.Property.PropertyInfo.PropertyType == typeof(bool))
            {
                dtdId = -49; // True/False
            }

            if (fieldConfig.Property.PropertyInfo.PropertyType == typeof(int)
                || fieldConfig.Property.PropertyInfo.PropertyType == typeof(long))
            {
                dtdId = -51; // Numeric
            }

            return dtdId;
        }
    }
}
