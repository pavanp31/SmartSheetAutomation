using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetObjectModel
{
    /// <summary>
    /// Creating object model for sheet Object
    /// </summary>
    public class Sheet
    {
        public string name;
        public Columns[] columns = null;
        public Sheet(string sheetName ,Columns[] columns)
        {
            this.name = sheetName;
            this.columns = columns;
        }      

    }

    public class Columns
    {
        public string title { get; set; }
        public string type { get; set; }
        public bool primary { get; set; }

        public static Columns CreateColumn(string type)
        {

            switch (type)
            {
                case "CHECKBOX":
                    return new ColumnA();
                case "TEXT_NUMBER":
                    return new ColumnB();
                default:
                    return null;

            }
        }
    }

    public class ColumnA : Columns
    {
        public string symbol { get; set; }
    }

    public class ColumnB :Columns
    {

    }

}
