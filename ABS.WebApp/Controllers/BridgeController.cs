using System;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using ABS.FileGeneration;

namespace ABS.WebApp
{
    public class MyBridgeController : ApiController
    {
        //private readonly FileGenerationService _fileGenService;

        public MyBridgeController()
        {
            // Initialize an instance of your .NET 7.0 class library
            //_fileGenService = new FileGenerationService();
        }

        // GET api/mybridge/getexcel
        [HttpGet]
        [Route("api/mybridge/getexcel")]
        public HttpResponseMessage GetExcelFile()
        {
            try
            {
                // Call a method in your .NET 7.0 class library to generate the Excel file
                byte[] excelData = FileGenerationService.GenerateRandomExcelFile();

                // Create an HttpResponseMessage to return the Excel file
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(excelData);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "example.xlsx" // Set the file name here
                };

                return response;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an appropriate error response
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}
