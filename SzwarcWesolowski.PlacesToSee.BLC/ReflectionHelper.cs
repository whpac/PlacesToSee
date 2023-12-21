using System.Reflection;

namespace SzwarcWesolowski.PlacesToSee.BLC
{
    internal class ReflectionHelper
    {
        internal static IEnumerable<Type> GetTypesFromAssembly(string assemblyPath, Type? baseType = null, Func<Type, bool>? predicate = null)
        {
            // By default don't filter the types
            baseType ??= typeof(object);
            predicate ??= _ => true;

            Assembly assembly = Assembly.UnsafeLoadFrom(assemblyPath);
            var foundTypes = assembly.GetTypes()
                .Where((t) => t.IsAssignableTo(baseType))
                .Where(predicate)
                .ToList();

            return foundTypes;
        }

        internal static T CreateInstance<T>(Type t, object?[]? constructorParams = null)
        {
            var instance = Activator.CreateInstance(t, constructorParams);
            return (T)instance!;
        }
    }
}

