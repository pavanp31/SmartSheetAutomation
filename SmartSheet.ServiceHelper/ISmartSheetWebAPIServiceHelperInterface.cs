using System;

namespace SmartSheet.ServiceHelper
{
    public interface ISmartSheetWebAPIServiceHelperInterface
    {

        string CreateSheet();

        string UpdateSheet(string id);


        string DeleteSheet(string id);


    }
}
