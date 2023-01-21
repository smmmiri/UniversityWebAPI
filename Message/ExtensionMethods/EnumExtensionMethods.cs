using System.ComponentModel;

namespace Message.ExtensionMethods
{
    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum e)
        {
            var descriptionAttribute = e.GetType().GetMember(e.ToString())[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0]
                        as DescriptionAttribute;

            return descriptionAttribute.Description;
        }
    }
}
