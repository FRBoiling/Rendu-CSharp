using System;
using Unity.Entities;

[Serializable]
public struct DebugMessageComponent : IComponentData
{
   public string message;
}

