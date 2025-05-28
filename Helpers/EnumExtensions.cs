using System.ComponentModel.DataAnnotations;

namespace DespesasAutomotivas.Helpers;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        return value.GetType()
                    .GetField(value.ToString())?
                    .GetCustomAttributes(typeof(DisplayAttribute), false)
                    is DisplayAttribute[] attributes && attributes.Any()
            ? attributes.First().Name
            : value.ToString();
    }
}
