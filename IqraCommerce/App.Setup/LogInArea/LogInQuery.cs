using System;
using System.Collections.Generic;
using System.Text;

namespace App.Setup.LogInArea
{
    public class LogInQuery
    {
        public static string AuthentiationToken { get { return "datacontent"; } }
        public static string DeviceCookie { get { return "bonik_device"; } }
        public static string GetUser(string SessionId)
        {
            return @"SELECT cstmr.[Id]
      ,[Name]
      ,[Phone]
      ,[Email]
      ,ssn.[IsActive]
  FROM [dbo].[Customer] cstmr
  inner join [dbo].[LogedInSession] ssn on cstmr.Id = ssn.UserId
  where ssn.Id = '" + SessionId + "';";
        }
        public static string GetUser(string UserName, string Password)
        {
            return @"SELECT cstmr.[Id]
              ,[Name]
              ,[Phone]
              ,[Email]
          FROM [dbo].[Customer] cstmr Where [Phone] = '" + UserName + "' And [Password] = '" + UserName + "'";
        }
    }
}
