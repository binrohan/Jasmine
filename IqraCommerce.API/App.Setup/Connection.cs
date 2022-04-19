using System;
using System.Collections.Generic;
using System.Text;

namespace App.Setup.Connection
{
    public class Connection
    {
        public static string DBName { get { return "ECommerce"; } }
        public static string ConnectionString = @"data source=103.108.140.160,1434;initial catalog=" + DBName + ";persist security info=True;user id=devrohan;password=dev.rohan!@#123;MultipleActiveResultSets=True";
        public static string ReportConnectionString = ConnectionString;


    }
}
