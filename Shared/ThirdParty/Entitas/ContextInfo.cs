using System;

namespace Entitas
{
    public class ContextInfo
    {
        public readonly string[] componentNames;
        public readonly Type[] componentTypes;

        public readonly string name;

        public ContextInfo(string name, string[] componentNames, Type[] componentTypes)
        {
            this.name = name;
            this.componentNames = componentNames;
            this.componentTypes = componentTypes;
        }
    }
}