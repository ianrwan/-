using System;

namespace Megumin.MeguminException
{
    public class ExistException : Exception
    {
        private static string err = "No Component in this GameObject";
        public ExistException() : base(err){}
        public ExistException(string message) : base(message){}
        public ExistException(string message, Exception inner) : base(message, inner){}
    }
}
