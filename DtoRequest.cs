using System.Collections.Generic;

namespace MadSoul.Common;

/// <summary>
/// base request class 
/// </summary>
public class DtoRequest
{
    public string? Username { get; set; }
    public string? Token { get; set; }
    public string? Identity { get; set; }
    public List<string> Roles { get; set; } = [];
    public List<string> Claims { get; set; } = [];
}

/// <summary>
/// base request class containing all Auth params
/// </summary>
/// <typeparam name="T"></typeparam>
public class DtoRequest<T> : DtoRequest
{
    public T? Data { get; set; }
}