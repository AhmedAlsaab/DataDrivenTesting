using System;
using excel = Microsoft.Office.Interop.Excel;

namespace ExcelOperations
{
    public class ExcelFileReader
    {

        readonly string ExcelFileLocationHome = @"C:\Users\a\Documents\DDT\DataDrivenTesting\ExcelOperations\Data\TestData.xlsx";


        // Look values up from Excel through row num, colum num and specify which sheet to look in
        public string ExcelLookup(int x, int y, int sheetNum)
        {
            excel.Application Xapp = new excel.Application();
            excel.Workbook xWorkbook = Xapp.Workbooks.Open(ExcelFileLocationHome);
            try
            {
                excel.Worksheet xWorksheet = xWorkbook.Sheets[sheetNum];
                excel.Range xRange = xWorksheet.UsedRange;
                return xRange.Cells[x][y].Value.ToString();
            }
            // Release Excel & Quit (Prevents Excel processes from ramping up)
            finally
            {
                xWorkbook.Close(true);
                Xapp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Xapp);
            }
        }
    }
       
}
