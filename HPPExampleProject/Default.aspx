<%@ Page Title="Make a Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HPPExampleProject._Default" %>

<asp:Content ID="HeaderScripts" ContentPlaceHolderID="ScriptContent" runat="server">

    <script src="<%= ResolveUrl("~/Scripts/rxp-js.min.js") %>"></script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <button type="button" id="payButtonId">Checkout Now</button>
    <script>
        // get the HPP JSON from the server-side SDK
        jQuery(document).ready(function () {
            jQuery.getJSON("<%= ResolveUrl("~/StartHppRequest.ashx") %>", function (json) {
                // if testing
                RealexHpp.setHppUrl("https://pay.sandbox.realexpayments.com/pay");
                RealexHpp.init("payButtonId", "<%= ResolveUrl("~/Response") %>", json);
            });
        });
    </script>

</asp:Content>
