using System;

namespace Megumin.MeguminException
{
    public class NoComponentException : Exception
    {
        private static string err = "No Component in this GameObject";
        public NoComponentException() : base(err){}
        public NoComponentException(string message) : base(message){}
        public NoComponentException(string message, Exception inner) : base(message, inner){}
    }
}
