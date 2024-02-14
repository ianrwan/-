using System;

namespace Megumin.MeguminException
{
    public static class ExceptionHandleWord
    {
        public static string exceptionWordFilePath = 
        "Please set up the path by using the Method \"SetPath(string path)\""+
        "or input the parameter in the function you want to do like \"ReadFileToString(string path)\"";

        public static string exceptionWordWriteWrong = "Here is something wrong when writing file.";
        public static string exceptionWordReadWrong = "Here is something wrong when writing file.";

        public static string JsonSerealWrong = "Here is something wrong when serealizing Json";
        public static string JsonDeSerealWrong = "Here is something wrong when deserealizing Json";
    }

    public class BattleButtonException : Exception
    {
        private static string err = "Here is something wrong in Battle Button";
        public BattleButtonException() : base(err)
        {

        }

        public BattleButtonException(string message) : base(message)
        {

        }

        public BattleButtonException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
