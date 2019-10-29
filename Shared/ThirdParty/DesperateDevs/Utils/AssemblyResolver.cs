using DesperateDevs.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DesperateDevs.Utils
{
  public class AssemblyResolver
  {
    private readonly Logger _logger = fabl.GetLogger(typeof (AssemblyResolver).Name);
    private readonly bool _reflectionOnly;
    private readonly string[] _basePaths;
    private readonly HashSet<Assembly> _assemblies;
    private readonly AppDomain _appDomain;

    public Assembly[] assemblies
    {
      get
      {
        return this._assemblies.ToArray<Assembly>();
      }
    }

    public AssemblyResolver(bool reflectionOnly, params string[] basePaths)
    {
      this._reflectionOnly = reflectionOnly;
      this._basePaths = basePaths;
      this._assemblies = new HashSet<Assembly>();
      this._appDomain = AppDomain.CurrentDomain;
      if (reflectionOnly)
        this._appDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(this.onReflectionOnlyAssemblyResolve);
      else
        this._appDomain.AssemblyResolve += new ResolveEventHandler(this.onAssemblyResolve);
    }

    public void Load(string path)
    {
      if (this._reflectionOnly)
      {
        this._logger.Debug(this._appDomain.ToString() + " reflect: " + path);
        this.resolveAndLoad(path, new Func<string, Assembly>(Assembly.ReflectionOnlyLoadFrom), false);
      }
      else
      {
        this._logger.Debug(this._appDomain.ToString() + " load: " + path);
        this.resolveAndLoad(path, new Func<string, Assembly>(Assembly.LoadFrom), false);
      }
    }

    public void Close()
    {
      if (this._reflectionOnly)
        this._appDomain.ReflectionOnlyAssemblyResolve -= new ResolveEventHandler(this.onReflectionOnlyAssemblyResolve);
      else
        this._appDomain.AssemblyResolve -= new ResolveEventHandler(this.onAssemblyResolve);
    }

    private Assembly resolveAndLoad(
      string name,
      Func<string, Assembly> loadMethod,
      bool isDependency)
    {
      Assembly assembly = (Assembly) null;
      try
      {
        if (isDependency)
          this._logger.Debug("  ➜ Loading Dependency: " + name);
        else
          this._logger.Debug("  ➜ Loading: " + name);
        assembly = loadMethod(name);
        this.addAssembly(assembly);
      }
      catch (Exception ex1)
      {
        string str = this.resolvePath(name);
        if (str != null)
        {
          try
          {
            assembly = loadMethod(str);
            this.addAssembly(assembly);
          }
          catch (BadImageFormatException ex2)
          {
          }
        }
      }
      return assembly;
    }

    private Assembly onAssemblyResolve(object sender, ResolveEventArgs args)
    {
      return this.resolveAndLoad(args.Name, new Func<string, Assembly>(Assembly.LoadFrom), true);
    }

    private Assembly onReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
    {
      return this.resolveAndLoad(args.Name, new Func<string, Assembly>(Assembly.ReflectionOnlyLoadFrom), true);
    }

    private void addAssembly(Assembly assembly)
    {
      this._assemblies.Add(assembly);
    }

    private string resolvePath(string name)
    {
      try
      {
        string name1 = new AssemblyName(name).Name;
        if (!name1.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) && !name1.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
          name1 += ".dll";
        foreach (string basePath in this._basePaths)
        {
          string path = basePath + Path.DirectorySeparatorChar.ToString() + name1;
          if (File.Exists(path))
          {
            this._logger.Debug("    ➜ Resolved: " + path);
            return path;
          }
        }
      }
      catch (FileLoadException ex)
      {
        this._logger.Debug("    × Could not resolve: " + name);
      }
      return (string) null;
    }

    public Type[] GetTypes()
    {
      return ((IEnumerable<Assembly>) this._assemblies.ToArray<Assembly>()).GetAllTypes();
    }

    public static AssemblyResolver LoadAssemblies(
      bool allDirectories,
      params string[] basePaths)
    {
      AssemblyResolver assemblyResolver = new AssemblyResolver(false, basePaths);
      foreach (string assemblyFile in AssemblyResolver.getAssemblyFiles(allDirectories, basePaths))
        assemblyResolver.Load(assemblyFile);
      return assemblyResolver;
    }

    public static Assembly[] GetAssembliesContainingType<T>(
      bool allDirectories,
      params string[] basePaths)
    {
      AssemblyResolver assemblyResolver = new AssemblyResolver(true, basePaths);
      foreach (string assemblyFile in AssemblyResolver.getAssemblyFiles(allDirectories, basePaths))
        assemblyResolver.Load(assemblyFile);
      string interfaceName = typeof (T).FullName;
      Assembly[] array = ((IEnumerable<Type>) assemblyResolver.GetTypes()).Where<Type>((Func<Type, bool>) (type => type.GetInterface(interfaceName) != null)).Select<Type, Assembly>((Func<Type, Assembly>) (type => type.Assembly)).Distinct<Assembly>().ToArray<Assembly>();
      assemblyResolver.Close();
      return array;
    }

    public static AssemblyResolver LoadAssembliesContainingType<T>(
      bool allDirectories,
      params string[] basePaths)
    {
      Assembly[] assembliesContainingType = AssemblyResolver.GetAssembliesContainingType<T>(allDirectories, basePaths);
      AssemblyResolver assemblyResolver = new AssemblyResolver(false, basePaths);
      foreach (Assembly assembly in assembliesContainingType)
        assemblyResolver.Load(assembly.CodeBase);
      return assemblyResolver;
    }

    private static string[] getAssemblyFiles(bool allDirectories, params string[] basePaths)
    {
      string[] strArray = new string[2]{ "*.dll", "*.exe" };
      List<string> stringList = new List<string>();
      foreach (string str in strArray)
      {
        string pattern = str;
        stringList.AddRange(((IEnumerable<string>) basePaths).SelectMany<string, string>((Func<string, IEnumerable<string>>) (s => (IEnumerable<string>) Directory.GetFiles(s, pattern, allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))));
      }
      return stringList.ToArray();
    }
  }
}