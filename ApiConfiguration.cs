using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MadSoul.Common;

public interface IApiConfiguration
{
    public string BaseUrl { get; }
}

public static class ApiConfigurationExtensions
{
    public static List<(Type defenation, Type implementation)> ListApiConfigInterfaces()
    {
        var result = new List<(Type defenation, Type implementation)>();

        //startup-host
        var startupAssembly = Assembly.GetEntryAssembly();

        // Get the assembly where your target interface resides
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName != startupAssembly?.FullName);


        if (startupAssembly is null)
            return result;

        // Define the base interface to search for
        var targetInterface = typeof(IApiConfiguration);

        // Scan for all interfaces in the assembly that extend the target interface
        var interfaces = assemblies.SelectMany(x => x.GetTypes()
                .Where(type =>
                    type.IsInterface &&
                    targetInterface.IsAssignableFrom(type) &&
                    type != targetInterface)
        ).ToList();


        var startupImplementations = startupAssembly.GetTypes()
            .Where(type =>
                type.IsClass &&
                interfaces.Any(x => x.IsAssignableFrom(type)) &&
                type != targetInterface).ToList();

        foreach (var @interface in interfaces)
        {
            var implementation = startupImplementations.FirstOrDefault(x => @interface.IsAssignableFrom(x));
            if (implementation is null)
                continue;
            result.Add((@interface, implementation));
        }

        return result;
    }
}