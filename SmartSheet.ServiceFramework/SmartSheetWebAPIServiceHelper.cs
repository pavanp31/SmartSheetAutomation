using CommonUtil;
using Newtonsoft.Json;
using SmartSheetObjectModel;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SmartSheet.ServiceHelper
{
    public class SmartSheetWebAPIServiceHelper : ISmartSheetWebAPIServiceHelperInterface
    {
        Sheet _sheet = null;

        public SmartSheetWebAPIServiceHelper(Sheet smartSheet)
        {
            _sheet = smartSheet;
        }

        /// <summary>
        /// Method to creare sheet via API
        /// </summary>
        /// <returns></returns>
        public string CreateSheet()
        {
            if (_sheet == null)
                throw new Exception("Sheet object should not be null");

            var requestUri = new Uri("https://api.smartsheet.com/2.0/sheets");//Constant.APIBaseURL);//, Constant.APIActions.Sheets.ToString()));
            string responseMessage = null;
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    // Convert Sheet object to JSON object.
                    string json = JsonConvert.SerializeObject(_sheet, typeof(Sheet),null);

                    // Make a string content out of the JSON.        
                    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constant.Token);

                    // Get the response and verify
                    HttpResponseMessage response = client.PostAsync(requestUri, httpContent).Result;
                    if (HttpStatusCode.OK != response.StatusCode)
                        throw new Exception("Failed to create Sheet");

                    //Retrieve string content
                    responseMessage = response.Content.ReadAsStringAsync().Result;
                }

                return responseMessage;
            }
            catch
            {
                return responseMessage;
            }
        }

        public string DeleteSheet(string id)
        {
            throw new NotImplementedException();
        }

        public string UpdateSheet(string id)
        {
            throw new NotImplementedException();
        }
    }
}
