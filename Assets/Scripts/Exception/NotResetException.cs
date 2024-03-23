using System;

namespace Megumin.MeguminException
{
    public class NotResetException : Exception
    {
        private static string err = "Here is something wrong when setting up";
        public NotResetException() : base(err){}
        public NotResetException(string message) : base(message){}
        public NotResetException(string message, Exception inner) : base(message, inner){}
    }
}
