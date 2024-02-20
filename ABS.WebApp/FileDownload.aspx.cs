using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABS.FileGeneration;

namespace ABS.WebApp
{
    public partial class FileDownload : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string downloadMessage = "";
                string fileName = "excel_export.xlsx";

                // Call the function that returns the byte[] array
                byte[] excelFileContent = FileGenerationService.GenerateRandomExcelFile();

                if (excelFileContent != null && excelFileContent.Length > 0)
                {
                    // Set the content type and disposition headers
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));

                    // Write the file content to the response stream
                    Response.BinaryWrite(excelFileContent);
                    Response.End();

                    downloadMessage = string.Format("File {0} downloaded", fileName);
                }
                else
                {
                    downloadMessage = string.Format("File not generated, please try your request again.", fileName);
                }

                MessageLabel.Text = downloadMessage;

            }
            catch (Exception)
            {
                //TODO: write out the exception for logging... DON'T just give it to the console
                MessageLabel.Text = "Error encountered during Excel file generation.";
            }

        }
    }
}