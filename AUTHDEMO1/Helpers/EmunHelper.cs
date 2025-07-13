namespace AUTHDEMO1.Helpers;
using System.ComponentModel.DataAnnotations;

public static class EnumHelper
{
    public static IEnumerable<object> GetEnumAsList<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new
            {
                Id = Convert.ToInt32(e),
                Name = GetDisplayName(e)
            });
    }

    private static string GetDisplayName<T>(T enumValue) where T : Enum
    {
        var member = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
        var displayAttr = member?.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
        return displayAttr?.Name ?? enumValue.ToString();
    }
}