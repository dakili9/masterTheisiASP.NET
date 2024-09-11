using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;


namespace MasterThesisASP.NET.Enums;

public static class EnumExtensions
{
    public static string GetStringValue(this Enum value)
{
    if (value == null)
    {
        return string.Empty;
    }

    var memberInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();

    return memberInfo?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? string.Empty;
}
}
