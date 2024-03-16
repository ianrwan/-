using System;

namespace Megumin.MeguminException
{
    public class NotMatchException : Exception
    {
        private static string err = "No Component in this GameObject";
        public NotMatchException() : base(err){}
        public NotMatchException(string message) : base(message){}
        public NotMatchException(string message, Exception inner) : base(message, inner){}
    }
}