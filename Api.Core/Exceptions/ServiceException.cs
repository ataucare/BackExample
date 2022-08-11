﻿namespace Api.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string? message, Exception? innerException)
            : base(message, innerException)
        { }

        public ServiceException(string? message)
            : base(message)
        { }
    }
}
