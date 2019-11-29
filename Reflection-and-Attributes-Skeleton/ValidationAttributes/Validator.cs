using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var objProperties = obj.GetType()
                .GetProperties();

            foreach (var propertyInfo in objProperties)
            {
                var propAttributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (var propAttribute in propAttributes)
                {
                    bool result = propAttribute.IsValid(propertyInfo.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
