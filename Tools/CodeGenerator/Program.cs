using System;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;
using Entitas.Migration;
using Microsoft.CSharp;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextsMigration = new ContextsMigration();
            MigrationUtils.WriteFiles(contextsMigration.Migrate("./Generated/")); 
            
            Console.WriteLine("Hello World!");
        }
    }


}