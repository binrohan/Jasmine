using System;
using System.Collections.Generic;
using System.Text;

namespace App.Setup
{
    public class Connection
    {
        public static string DBName { get { return "SHOPPERS_PERK_DB"; } }
        public static string ConnectionString = @"data source=DESKTOP-2T4KNKA;initial catalog=SHOPPERS_PERK_DB;persist security info=True;user id=sa;password=123;MultipleActiveResultSets=True";
        public static string ReportConnectionString = ConnectionString;


    }
}
