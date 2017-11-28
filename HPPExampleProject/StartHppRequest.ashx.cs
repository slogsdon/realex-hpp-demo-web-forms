using GlobalPayments.Api;
using GlobalPayments.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPPExampleProject
{
    /// <summary>
    /// Summary description for StartHppRequest
    /// </summary>
    public class StartHppRequest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var service = new HostedService(new ServicesConfig
            {
                MerchantId = "heartlandgpsandbox",
                AccountId = "hpp",
                SharedSecret = "secret",
                ServiceUrl = "https://pay.sandbox.realexpayments.com/pay",
                HostedPaymentConfig = new HostedPaymentConfig
                {
                    Language = "en",
                },
            });

            var json = service.Authorize(100)
                .WithCurrency("EUR")
                .Serialize();

            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}