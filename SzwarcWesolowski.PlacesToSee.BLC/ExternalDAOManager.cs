using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.BLC
{
    public class ExternalDAOManager
    {
        private static IDAO? daoInstance = null;

        public static bool IsInitialized => daoInstance != null;

        public static IDAO GetDAOInstance()
        {
            if (daoInstance != null) return daoInstance;
            throw new NullReferenceException("There's no DAO instance initialized yet.");
        }

        public static void Initialize(string dllPath)
        {
            if (daoInstance != null)
            {
                throw new InvalidOperationException($"The {nameof(ExternalDAOManager)} is already initialized to an instance of DAO object.");
            }

            var types = ReflectionHelper.GetTypesFromAssembly(dllPath, typeof(IDAO));
            var typeCount = types.Count();

            if (typeCount == 1)
            {
                daoInstance = ReflectionHelper.CreateInstance<IDAO>(types.First());
            }
            else if (typeCount == 0)
            {
                throw new InvalidDataException($"The library at '{dllPath}' contains no definition of {nameof(IDAO)} type to be used as data source.");
            }
            else
            {
                throw new InvalidDataException($"The library at '{dllPath}' contains more than one definition of {nameof(IDAO)} type that can be used as data source. Aborting.");
            }
        }
    }
}
