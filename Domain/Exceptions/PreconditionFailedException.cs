using System;

namespace Domain.Exceptions
{
    public class PreconditionFailedException : DomainException
    {
        public PreconditionFailedException()
        {
        }

        public PreconditionFailedException(string message)
            : base(message)
        {
        }

        public PreconditionFailedException(string message, Exception inner)
            :base(message, inner)
        {
        }
    }
}