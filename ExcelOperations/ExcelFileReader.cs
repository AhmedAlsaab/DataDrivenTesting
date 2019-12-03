namespace AutomationExcel
{
    public class ExcelFileReader
    {
        readonly String ExcelFileLocationHome = @"Your Location";
        readonly String ExcelFileLocationWork = @"Your Location";

        // Lookup values from Excel Workbook to use as data in Automation
        public string ExcelLookup(int x, int y, int sheetNum)
        {
            excel.Application Xapp = new excel.Application();
            excel.Workbook xWorkbook = Xapp.Workbooks.Open(ExcelFileLocationWork);
            try
            {
                excel.Worksheet xWorksheet = xWorkbook.Sheets[sheetNum];
                excel.Range xRange = xWorksheet.UsedRange;
                return xRange.Cells[x][y].Value.ToString();

            } catch (RuntimeBinderException)
            {
                string emptyValue = "Empty/Invalid Value: Check your selected data set!";
                System.Diagnostics.Debug.WriteLine("Null value found, check Excel values");
                Console.Write("Null value found, check Excel values");
                return emptyValue;
            }
            // Release Excel & Quit (Prevents Excel processes from ramping up)
            finally
            {
                xWorkbook.Close(true);
                Xapp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Xapp);
            }
        }
        // Writing Quote Results to Excel
        public void SaveToExcel(int x, int y, string dataToSend, int sheetNum)
        {
            excel.Application Xapp = new excel.Application();
            excel.Workbook xWorkbook = Xapp.Workbooks.Open(ExcelFileLocationWork);
            try
            {
                excel.Worksheet xWorksheet = xWorkbook.Sheets[sheetNum];
                excel.Range xRange = xWorksheet.UsedRange;
                xRange.Cells[x, y] = dataToSend;
                xWorkbook.Save();
            }
            finally
            {
                xWorkbook.Close(true);
                Xapp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Xapp);
            }
        }
    }
}
