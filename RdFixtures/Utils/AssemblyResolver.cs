using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Rd.Logging;

namespace Rd.Utils
{
    public class AssemblyResolver
    {
        private readonly AppDomain _appDomain;
        private readonly HashSet<Assembly> _assemblies;
        private readonly string[] _basePaths;
        private readonly Logger _logger = fabl.GetLogger(typeof(AssemblyResolver).Name);
        private readonly bool _reflectionOnly;

        public AssemblyResolver(bool reflectionOnly, params string[] basePaths)
        {
            _reflectionOnly = reflectionOnly;
            _basePaths = basePaths;
            _assemblies = new HashSet<Assembly>();
            _appDomain = AppDomain.CurrentDomain;
            if (reflectionOnly)
                _appDomain.ReflectionOnlyAssemblyResolve += onReflectionOnlyAssemblyResolve;
            else
                _appDomain.AssemblyResolve += onAssemblyResolve;
        }

        public Assembly[] assemblies => _assemblies.ToArray();

        public void Load(string path)
        {
            if (_reflectionOnly)
            {
                _logger.Debug(_appDomain + " reflect: " + path);
                resolveAndLoad(path, Assembly.ReflectionOnlyLoadFrom, false);
            }
            else
            {
                _logger.Debug(_appDomain + " load: " + path);
                resolveAndLoad(path, Assembly.LoadFrom, false);
            }
        }

        public void Close()
        {
            if (_reflectionOnly)
                _appDomain.ReflectionOnlyAssemblyResolve -= onReflectionOnlyAssemblyResolve;
            else
                _appDomain.AssemblyResolve -= onAssemblyResolve;
        }

        private Assembly resolveAndLoad(
            string name,
            Func<string, Assembly> loadMethod,
            bool isDependency)
        {
            var assembly = (Assembly) null;
            try
            {
                if (isDependency)
                    _logger.Debug("  ➜ Loading Dependency: " + name);
                else
                    _logger.Debug("  ➜ Loading: " + name);
                assembly = loadMethod(name);
                addAssembly(assembly);
            }
            catch (Exception ex1)
            {
                var str = resolvePath(name);
                if (str != null)
                    try
                    {
                        assembly = loadMethod(str);
                        addAssembly(assembly);
                    }
                    catch (BadImageFormatException ex2)
                    {
                    }
            }

            return assembly;
        }

        private Assembly onAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return resolveAndLoad(args.Name, Assembly.LoadFrom, true);
        }

        private Assembly onReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return resolveAndLoad(args.Name, Assembly.ReflectionOnlyLoadFrom, true);
        }

        private void addAssembly(Assembly assembly)
        {
            _assemblies.Add(assembly);
        }

        private string resolvePath(string name)
        {
            try
            {
                var name1 = new AssemblyName(name).Name;
                if (!name1.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) && !name1.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                    name1 += ".dll";
                foreach (var basePath in _basePaths)
                {
                    var path = basePath + Path.DirectorySeparatorChar + name1;
                    if (File.Exists(path))
                    {
                        _logger.Debug("    ➜ Resolved: " + path);
                        return path;
                    }
                }
            }
            catch (FileLoadException ex)
            {
                _logger.Debug("    × Could not resolve: " + name);
            }

            return null;
        }

        public Type[] GetTypes()
        {
            return _assemblies.ToArray().GetAllTypes();
        }

        public static AssemblyResolver LoadAssemblies(
            bool allDirectories,
            params string[] basePaths)
        {
            var assemblyResolver = new AssemblyResolver(false, basePaths);
            foreach (var assemblyFile in getAssemblyFiles(allDirectories, basePaths))
                assemblyResolver.Load(assemblyFile);
            return assemblyResolver;
        }

        public static Assembly[] GetAssembliesContainingType<T>(
            bool allDirectories,
            params string[] basePaths)
        {
            var assemblyResolver = new AssemblyResolver(true, basePaths);
            foreach (var assemblyFile in getAssemblyFiles(allDirectories, basePaths))
                assemblyResolver.Load(assemblyFile);
            var interfaceName = typeof(T).FullName;
            var array = assemblyResolver.GetTypes().Where(type => type.GetInterface(interfaceName) != null).Select(type => type.Assembly).Distinct().ToArray();
            assemblyResolver.Close();
            return array;
        }

        public static AssemblyResolver LoadAssembliesContainingType<T>(
            bool allDirectories,
            params string[] basePaths)
        {
            var assembliesContainingType = GetAssembliesContainingType<T>(allDirectories, basePaths);
            var assemblyResolver = new AssemblyResolver(false, basePaths);
            foreach (var assembly in assembliesContainingType)
                assemblyResolver.Load(assembly.CodeBase);
            return assemblyResolver;
        }

        private static string[] getAssemblyFiles(bool allDirectories, params string[] basePaths)
        {
            var strArray = new string[2] {"*.dll", "*.exe"};
            var stringList = new List<string>();
            foreach (var str in strArray)
            {
                var pattern = str;
                stringList.AddRange(basePaths.SelectMany(s =>
                    (IEnumerable<string>) Directory.GetFiles(s, pattern, allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)));
            }

            return stringList.ToArray();
        }
    }
}