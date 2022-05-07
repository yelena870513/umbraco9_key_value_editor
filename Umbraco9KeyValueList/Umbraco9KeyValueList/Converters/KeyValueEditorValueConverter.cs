using System.Collections.Generic;
using Newtonsoft.Json;
using Umbraco9KeyValueList.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace Umbraco9KeyValueList.Converters
{
    public class KeyValueEditorValueConverter: IPropertyValueConverter
    {
        /// <summary>
        /// Value converter class to convert a json key value pairs object
        /// to a strongly typed key value pairs instance.
        /// </summary>
        [PropertyValueType(typeof(Dictionary<string, string>))]
        [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
        public class KeyValueEditorValueConverter : PropertyValueConverterBase
        {
            /// <summary>
            /// Method to convert a property value to an instance
            /// of the key value pairs class.
            /// </summary>
            /// <param name="propertyType">The current published property
            /// type to convert.</param>
            /// <param name="source">The original property data.</param>
            /// <param name="preview">True if in preview mode.</param>
            /// <returns>An instance of the key value pairs class.</returns>
            public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
            {
                if (source == null)
                    return null;

                if (UmbracoContext.Current == null)
                    return null;

                var retval = new Dictionary<string, string>();

                var pairs = JsonConvert.DeserializeObject<KeyValueEditorPairs>(source.ToString());
                if (pairs == null || pairs.Count < 0)
                    return retval;

                foreach (var pair in pairs)
                    retval.Add(pair.Key, pair.Value);

                return retval;
            }

            /// <summary>
            /// Method to see if the current property type is of type
            /// key value editor.
            /// </summary>
            /// <param name="propertyType">The current property type.</param>
            /// <returns>True if the current property type of of type
            /// key value editor.</returns>
            public override bool IsConverter(PublishedPropertyType propertyType)
            {
                return propertyType.EditorAlias.Equals("Umbraco9KeyValueList");
            }
        }
    }
}