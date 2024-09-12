using System;

namespace MasterThesisASP.NET.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string Message) : base(Message){}
}
