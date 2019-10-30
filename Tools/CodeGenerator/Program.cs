using System;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;
using Microsoft.CSharp;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = "Entitas.CodeGeneration.Plugins.Contexts = Game";
            var provider = new ContextDataProvider();
            provider.Configure(new RDPreferences(names));

            var dataArr = (ContextData[]) provider.GetData();
            foreach (var  data in dataArr)
            {
                string contextName = data.GetContextName();
            }
            
            var generator = new ContextGenerator();
            var files = generator.Generate(dataArr);
            Console.WriteLine("Hello World!");
        }
    }


}