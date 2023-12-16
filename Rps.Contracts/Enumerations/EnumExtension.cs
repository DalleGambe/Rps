using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Rps.Contracts.Enumerations
{
    public static class EnumExtension
    {
        public static string GetPropertyDisplayName<TEnum>(this TEnum enumValue)
        {
            var enumType = typeof(TEnum);
            var memberInfo = enumType.GetMember(enumValue.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                    return displayAttribute.GetName();
            }

            return enumValue.ToString();
        }
    }
}
