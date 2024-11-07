using System;

namespace MadSoul.Common;

public class DtoException : Exception
{
    public DtoException() {}

    public DtoException(string message) : base(message)
    {
        
    }
    
    public DtoException(string message , Exception ex) : base(message , ex)
    {
        InternalException = ex;
    }
    
    public Exception? InternalException { get;}
}