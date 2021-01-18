using System.Net;

namespace MyWasteAPI.Controllers
{
    internal class HttpStatusCodeResult
    {
        private HttpStatusCode badRequest;

        public HttpStatusCodeResult(HttpStatusCode badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}