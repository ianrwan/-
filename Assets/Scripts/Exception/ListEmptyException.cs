using System;

namespace Megumin.MeguminException
{
    public class ListEmptyException : Exception
    {
        private static string err = " GameObject is Missing";
        public ListEmptyException() : base(err){}
        public ListEmptyException(string message) : base(message){}
        public ListEmptyException(string message, Exception inner) : base(message, inner){}
    }
}
