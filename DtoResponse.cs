using System.Collections.Generic;

namespace MadSoul.Common;

public class DtoResponse
{
    public bool IsOk { get; set; }
    public int Code { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];
    public IEnumerable<string> Messages { get; set; } = [];
}

public class DtoResponse<T> : DtoResponse
{
    public T? Data { get; set; }
}