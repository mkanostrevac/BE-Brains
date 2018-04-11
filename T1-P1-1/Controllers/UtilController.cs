using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace T1_P1_1.Controllers
{
    [RoutePrefix("util")]
    public class UtilController : ApiController
    {
        [Route("date")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }

        [Route("family")]
        public IEnumerable<string> GetFamily()
        {
            return new string[] { "Marko", "Ivan", "Jelena" };
        }

        [Route("myclass")]
        public HttpResponseMessage GetMyClass()
        {
            string[] polaznici = new string[] { "Marko Markovic", "Ivana Ivanovic", "Nikola Nikolic" };
            string content = "<h1> Moja grupa </h1> ";

            foreach (string polaznik in polaznici)
            {
                content += "<p>" + polaznik + "</p>";
            }

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(content);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");

            return response;
        }
    }
}
