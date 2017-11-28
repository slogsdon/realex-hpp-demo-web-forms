using GlobalPayments.Api;
using GlobalPayments.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPPExampleProject
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["hppResponse"] != null)
            {
                string hppResponse = Request["hppResponse"];

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

                var response = service.ParseResponse(hppResponse, true);

                ResponseCode.Text = response.ResponseCode;
                ResponseMessage.Text = response.ResponseMessage;
            }
        }
    }
}