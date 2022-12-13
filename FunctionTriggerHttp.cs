using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Spark.Library.FSharp;

namespace CSharpFSharpTemplateProject
{
    public static class FunctionTriggerHttp
    {
        [FunctionName("FunctionTriggerHttp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string username = req.Query["username"];
            string password = req.Query["password"];

            Login login = new Login(42, username, password);
            Console.WriteLine(String.Format("Login state:{0}", ((ILogin)login).IsValid));

            string responseMessage = ((ILogin)login).IsValid
                ? String.Format("Login credentials for user:{0} is valid", username)
                : String.Format("Login credentials for user:{0} is invalid", username);

            return new OkObjectResult(responseMessage);
        }
    }
}
