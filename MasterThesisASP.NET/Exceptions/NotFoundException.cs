using System;

namespace MasterThesisASP.NET.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string Message) : base(Message) {}
}
