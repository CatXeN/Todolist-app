using System.ComponentModel;
using System.Reflection;

namespace TodolistAppDomain.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum item)
        {
            Type type = item.GetType();
            MemberInfo[] memberInfo = type.GetMember(item.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    return ((DescriptionAttribute)attributes[0]).Description;
            }

            return item.ToString();
        }
    }
}
