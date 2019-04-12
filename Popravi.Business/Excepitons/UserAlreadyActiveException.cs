using System;
using System.Runtime.Serialization;

namespace Popravi.Business.Exceptions
{
    [Serializable]
   public class UserAlreadyActiveException : Exception
    {
        public UserAlreadyActiveException()
        {
        }

        public UserAlreadyActiveException(string message) : base(message)
        {
        }

     
    }
}