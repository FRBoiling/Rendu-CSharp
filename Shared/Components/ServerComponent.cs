using Entitas;
using Entitas.CodeGeneration.Attributes;

[Context("Server")]
public class ServerComponent : IComponent
{
    private string _serverName;
}