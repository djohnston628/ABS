using OfficeOpenXml;

namespace ABS.FileGeneration
{
    public static class FileGenerationService
    {
        public static byte[] GenerateRandomExcelFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //FileInfo fileInfo = new FileInfo("randomExcel.xlsx");

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Generate random data for 5 rows and 5 columns
                Random random = new Random();
                for (int row = 1; row <= 5; row++)
                {
                    for (int col = 1; col <= 5; col++)
                    {
                        worksheet.Cells[row, col].Value = random.Next().ToString();
                    }
                }

                // Save the Excel package to a memory stream
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);

                // Return the byte array of the Excel file
                return stream.ToArray();
            }
        }
    }
}
