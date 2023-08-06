using System;

namespace zipandsendApp.Exception
{
    public class DomainException : ApplicationException
    {

        public DomainException(string message) : base(message)
        { 
        
        }
    }
}
