using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FatturaElettronica.Common
{
    public static class TypeExtensions
    {
        public static MethodInfo GetMethod(this Type type, string name)
        {
#if NET40
            return type.GetMethods().First(x => x.Name.Contains(name));
#else
            return type.GetRuntimeMethods().First(x => x.Name.Contains(name));
#endif
        }

        public static bool IsSubclassOfBusinessObject(this Type type)
        {
#if NET40
            return typeof(BaseClassSerializable).IsAssignableFrom(type);
#else
            return typeof(BaseClassSerializable).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
        }

        public static bool IsGenericList(this Type type)
        {
#if NET40
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
#else
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
#endif
        }
    }
}
