using System;
using System.Collections.Generic;
using System.Text;

namespace App.Setup.LogInArea
{
    public class LogInQuery
    {
        /// <summary>
        /// Header|Cookie
        /// </summary>
        public static AuthProcessType AuthProcess { get { return AuthProcessType.Cookie; } }
        public static string AuthentiationToken { get { return "datacontent"; } }
        public static string DeviceCookie { get { return "bonik_device"; } }
        public static string GetUser(string SessionId)
        {

            return @"
SELECT NewId()
      ,'Test'
      ,'017225025882'
      ,'sama@gmail.com'
      ,1";

  //          return @"SELECT cstmr.[Id]
  //    ,[Name]
  //    ,[Phone]
  //    ,[Email]
  //    ,ssn.[IsActive]
  //FROM [dbo].[Customer] cstmr
  //inner join [dbo].[LogedInSession] ssn on cstmr.Id = ssn.UserId
  //where ssn.Id = '" + SessionId + "';";
        }
        public static string GetUser(string UserName, string Password)
        {

            return @"
SELECT NewId()
      ,'Test'
      ,'017225025882'
      ,'sama@gmail.com'";
            //          return @"SELECT cstmr.[Id]
            //    ,[Name]
            //    ,[Phone]
            //    ,[Email]
            //FROM [dbo].[Customer] cstmr Where [Phone] = '" + UserName + "' And [Password] = '" + UserName + "'";
        }
    }
}
