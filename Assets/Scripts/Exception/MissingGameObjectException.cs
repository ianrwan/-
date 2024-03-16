using System;

namespace Megumin.MeguminException
{
    public class MissingGameObjectException : Exception
    {
        private static string err = " GameObject is Missing";
        public MissingGameObjectException() : base(err){}
        public MissingGameObjectException(string message) : base(message){}
        public MissingGameObjectException(string message, Exception inner) : base(message, inner){}
    }
}
