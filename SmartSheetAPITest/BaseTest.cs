using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSheetObjectModel;

namespace SmartSheetAPITest
{
    public class BaseTestAPI
    {

        /// <summary>
        /// Helper method to validate API response data
        /// </summary>
        /// <param name="response">Json response string</param>
        public void VerifyResponse(string response)
        {
            // Parse the response and verify fields
            JObject jsonRes = JObject.Parse(response);

            string message = jsonRes["message"].ToString();
            string id = jsonRes["result"]["id"].ToString();

            Assert.AreEqual(message, "SUCCESS", "Actual response message does not match with success!");
            Assert.IsNotNull(id, "ID should not be null");

        }
    }
}
