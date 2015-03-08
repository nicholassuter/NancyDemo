using Nancy;
using Nancy.ModelBinding;
using NancyDemo.Models;

namespace NancyDemo
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => { return View["index"]; };

            Get["/about"] = parameters => {
                var siteInformation = new SiteInformation
                {
                    Name = "My Nancy Demo",
                    Owner = "Nicholas Suter",
                    Description = "How to build fancy websites using Nancy ! ",
                    CreationDate = new System.DateTime(2014, 11, 16)
                };
                return View["about", siteInformation]; };

            var contactRequest = new ContactRequest();

            Get["/contact"] = parameters => { return View["contact", contactRequest]; };

            Post["/contact"] = parameters =>
            {
                contactRequest = this.Bind<ContactRequest>();

                return Response.AsRedirect("/?status=added&title=" + contactRequest.Email);
            };
        }
    }
}