using System;

namespace AcmeUI.Helpers
{
    /// <summary>
    /// Helper class for Reflection operations
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Gets the property value dynamically for given object by property name
        /// </summary>
        /// <param name="object">The object</param>
        /// <param name="propertyName">The property that value will retrieved</param>
        /// <returns>The value of the property</returns>
        public object GetPropertyValue(object @object, string propertyName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(nameof(@object));
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException(nameof(propertyName));
            }

            var objectType = @object.GetType();
            var property = objectType.GetProperty(propertyName);

            if (property == null)
            {
                throw new ArgumentException($"No such property {propertyName} of type {objectType.FullName}");
            }

            var value = property.GetValue(@object);

            return value;
        }
    }
}
