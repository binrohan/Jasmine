using System;
using System.Collections.Generic;
using System.Text;

namespace App.Setup
{

    public class TextProvider
    {
        public static class Response
        {
            public static string Success { get { return @"Success"; } }
            public static string Fail { get { return @"Fail"; } }
            public static string AlreadySignout { get { return @"Already Signout."; } }
            public static string WrongUserNameOrPassword { get { return @"Phone number or password does not match."; } }
        }
    }
}
