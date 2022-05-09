using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Umbraco9KeyValueList.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Web;

namespace Umbraco9KeyValueList.Converters
{
    public class KeyValueEditorValueConverter : IPropertyValueConverter
    {
        object IPropertyValueConverter.ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
        {
            return inter;
        }

        object IPropertyValueConverter.ConvertIntermediateToXPath(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
        {
            if (inter == null)
            {
                return null;
            }

            return inter.ToString();
        }

        object IPropertyValueConverter.ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null) return null;
            try
            {
                var obj = JsonConvert.DeserializeObject<KeyValueEditorPairs>(source.ToString());
                return obj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        PropertyCacheLevel IPropertyValueConverter.GetPropertyCacheLevel(IPublishedPropertyType propertyType)
        {
            return PropertyCacheLevel.Element;
        }

        Type IPropertyValueConverter.GetPropertyValueType(IPublishedPropertyType propertyType)
        {
            return typeof(KeyValueEditorPair);
        }

        bool IPropertyValueConverter.IsConverter(IPublishedPropertyType propertyType)
        {
            return propertyType.EditorAlias.Equals("Umbraco9KeyValueList");
        }

        bool? IPropertyValueConverter.IsValue(object value, PropertyValueLevel level)
        {
            switch (level)
            {
                case PropertyValueLevel.Source:
                    return value != null && value is KeyValueEditorPair;
                default:
                    throw new NotSupportedException($"Invalid level: {level}.");
            }
        }
    }
}