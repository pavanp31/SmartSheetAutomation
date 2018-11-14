using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetObjectModel
{
    public class SmartSheetObjectModelHelper
    {
        /// <summary>
        /// Creating sheet via API
        /// </summary>
        /// <param name="numberOfColumn">provide int value to add column in the sheet</param>
        /// <returns>return sheet object</returns>
        public static Sheet CreateSheetObjectWithDefaultValue(int numberOfColumn)
        {

            Sheet newSheet = null;
            Random random = new Random();

            // Creare unique sheetName
            string sheetName = "NewSheet_" + random.Next(100, 98796);

            // Create columns for sheet
            Columns[] columns = new Columns[numberOfColumn];
            for (int i = 0; i < numberOfColumn; i++)
            {
                var columnType = Enum.GetValues(typeof(Constant.ColumnType)).GetValue(i%2).ToString();
                var t = Columns.CreateColumn(columnType);
                if (t.GetType() == typeof(ColumnA))
                {
                    columns[i] = new ColumnA()
                    {
                        title = "title_" + random.Next(100, 98796),
                        type = columnType,
                        symbol = "STAR",
                        primary = i == 0 ? true : false
                    };
                }
                else
                {
                    columns[i] = new ColumnB()
                    {
                        title = "title_" + random.Next(100, 98796),
                        type = columnType,
                        primary = i == 0 ? true : false
                    };
                }
            }
            newSheet = new Sheet(sheetName, columns);
            return newSheet;
        }
    }
}
