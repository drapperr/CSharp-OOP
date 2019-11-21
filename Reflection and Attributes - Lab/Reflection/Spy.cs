using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.Public |
                                    BindingFlags.NonPublic |
                                    BindingFlags.Instance |
                                    BindingFlags.Static);

        var sb = new StringBuilder();

        var classInstance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var fieldInfo in fields.Where(x => fieldsNames.Contains(x.Name)))
        {
            string fieldName = fieldInfo.Name;
            var value = fieldInfo.GetValue(classInstance);

            sb.AppendLine($"{fieldName} = {value}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.Public |
                                  BindingFlags.Instance |
                                  BindingFlags.Static);
        foreach (var fieldInfo in fields)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        var methods = type.GetMethods(BindingFlags.Public |
                                      BindingFlags.NonPublic |
                                      BindingFlags.Instance);

        foreach (var getterInfo in methods.Where(x => !x.IsPublic && x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getterInfo.Name} have to be public!");
        }

        foreach (var setterInfo in methods.Where(x => x.IsPublic && x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setterInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();
        Type type = Type.GetType(className);
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        var methods = type.GetMethods(BindingFlags.NonPublic |
                                      BindingFlags.Instance);

        foreach (var methodInfo in methods)
        {
            sb.AppendLine(methodInfo.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        var methods = type.GetMethods(BindingFlags.Public |
                                      BindingFlags.NonPublic |
                                      BindingFlags.Instance);

        var sb = new StringBuilder();

        foreach (var getterInfo in methods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getterInfo.Name} will return {getterInfo.ReturnType}");
        }

        foreach (var setterInfo in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setterInfo.Name} will set field of {setterInfo.GetParameters().FirstOrDefault().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
