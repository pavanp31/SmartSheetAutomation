using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CommonUtil
{
    /// <summary>
    /// Class contains all the static variables like Base URL
    /// </summary>
    public class Constant
    {

        public static string APIBaseURL = ConfigurationManager.AppSettings["BaseUrl"];
        public static string TargetedBrowser = ConfigurationManager.AppSettings["TargetedBrowser"];
        public static string AppURL = ConfigurationManager.AppSettings["AppURL"];
        public static string UserName = ConfigurationManager.AppSettings["UserName"];
        public static string Password = ConfigurationManager.AppSettings["Pwd"];
        public static int WaitTimeInMiliSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["WaitTimeInMiliSeconds"]);
        public static string Token = ConfigurationManager.AppSettings["BearerToken"];

        /// <summary>
        /// API action collection
        /// </summary>
        public enum APIActions
        {
            Sheets,
            UpdateSheet
        }

        public enum ColumnType
        {
            TEXT_NUMBER,
            CHECKBOX
        }
    }
}
