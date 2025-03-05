using System;
using System.Collections.Generic;
using System.Text;

public class CodeBuilder
{
    private readonly string _className;
    private readonly List<(string Type, string Name)> _fields = new();

    public CodeBuilder(string className)
    {
        _className = className;
    }

    public CodeBuilder AddField(string name, string type)
    {
        _fields.Add((type, name));
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"public class {_className}");
        sb.AppendLine("{");

        foreach (var field in _fields)
        {
            sb.AppendLine($"  public {field.Type} {field.Name};");
        }

        sb.AppendLine("}");
        return sb.ToString();
    }
}

// Example usage
// class Program
// {
//     static void Main()
//     {
//         var cb = new CodeBuilder("Person")
//             .AddField("Name", "string")
//             .AddField("Age", "int");

//         Console.WriteLine(cb);
//     }
// }