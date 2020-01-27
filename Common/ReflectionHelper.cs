using System;

namespace BlazorExample
{
    public static class ReflectionHelper
    {
        public static bool IsDerivedFrom(this Type type, Type baseType)
        {
            while (type != null && type != typeof(object))
            {
                if (type == baseType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }
    }
}
