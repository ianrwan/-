using System;

namespace Megumin.MeguminException
{
    public class SetUpException : Exception
    {
        private static string err = "Here is something wrong when setting up";
        public SetUpException() : base(err){}
        public SetUpException(string message) : base(message){}
        public SetUpException(string message, Exception inner) : base(message, inner){}
    }
}
