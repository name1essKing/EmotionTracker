using System;
using System.Linq;
using System.Reflection;


namespace EmotionTracker.ui
{
    public static class Resolver
    {
        /// <summary>
        /// Assemblies the resolver.
        /// </summary>
        /// <param name="assemblyName">The assembly name.</param>
        /// <returns>An Assembly? .</returns>
        public static Assembly? AssemblyResolver(AssemblyName assemblyName)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == assemblyName.FullName);
        }

        /// <summary>
        /// Types the resolver.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="typeName">The type name.</param>
        /// <param name="b">If true, b.</param>
        /// <returns>A Type? .</returns>
        public static Type? TypeResolver(Assembly? assembly, string typeName, bool b)
        {
            if (assembly is not null)
            {
                return assembly.GetType(typeName);
            }
            else
            { return null; }
        }
    }
}
