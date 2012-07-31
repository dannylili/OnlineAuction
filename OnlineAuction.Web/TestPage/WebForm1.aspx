<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="OnlineAuction.Web.TestPage.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        fieldset
        {
            border: solid 1px #e2e2e2;
            color: #b9b9b9;
            display: inline-block;
            float: left;
            font-weight: bold;
            margin: 10px 5px 5px 0;
            min-height: 40px;
            padding: 10px;
            width: auto;
            background-image: -moz-linear-gradient(top, #ffffff, #efefef);
            background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #ffffff),color-stop(1, #efefef));
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorStr='#ffffff', EndColorStr='#efefef')";
        }
        input[type=radio]
        {
            border: 0;
            margin: 2px 2px 2px 2px;
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>我来了</legend>
        </fieldset>
        <fieldset>
            <legend>我来了</legend>
        </fieldset>
        <fieldset>
            <legend></legend>
            <input type="radio" value="选择" />
        </fieldset>
    </div>
    <div class="FormContainer ui-tabs ui-widget ui-widget-content ui-corner-all" id="e0777bfbab2349c59f284648a269f6c3"
        style="height: 291px;">
        <input name="__RequestVerificationToken" type="hidden" value="quVjIGyDCpfNcQ5eHbiY7jp7K7/PH5i2wVJ8bKBZnvH51tchZzpHT12kCSH+NbExGEU4qWiOWXHEX+qfdyk6awLugKagUBS5t0jGAowoLlGLc8lcxH10FALgaalpWhDnj+CDFh8XFN8uPTQtxGSehEGMEGM=">
        <ul id="Te0777bfbab2349c59f284648a269f6c3" class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
            <li class="ui-state-default ui-corner-top ui-tabs-selected ui-state-active"><a href="#MainTabe0777bfbab2349c59f284648a269f6c3">
                Main</a> </li>
            <li class="ui-state-default ui-corner-top"><a href="#ExceptionsCampaignActivitye0777bfbab2349c59f284648a269f6c3">
                List of Activities</a> </li>
        </ul>
        <div class="FormSection ui-tabs-panel ui-widget-content ui-corner-bottom" id="MainTabe0777bfbab2349c59f284648a269f6c3"
            style="height: 253px;">
            <fieldset class="Rounded" id="MainGroup">
                <legend>Main</legend>
                <div class="FormField" data-template="">
                    <div class="iHelp">
                    </div>
                    <label for="Token">
                        Token</label><span data-code="" data-token="" id="Token" name="Token">CPN001</span></div>
                <div class="FormField" data-template="">
                    <div class="iHelp">
                    </div>
                    <label for="Code">
                        Campaign</label><span data-code="" data-token="" id="Code" name="Code">Code</span></div>
                <div class="FormField" data-template="Integer">
                    <div class="iHelp">
                    </div>
                    <label for="StatusID">
                        Status</label><span data-code="Open" data-token="Open" id="StatusID" name="StatusID">Open</span></div>
                <div class="FormField" data-template="Date">
                    <div class="iHelp">
                    </div>
                    <label for="StartedOn">
                        Start Date</label><span data-code="" data-token="" id="StartedOn" name="StartedOn">7/10/2012</span></div>
                <div class="FormField" data-template="Date">
                    <div class="iHelp">
                    </div>
                    <label for="FinsihedOn">
                        End Date</label><span data-code="" data-token="" id="FinsihedOn" name="FinsihedOn">9/10/2012</span></div>
                <div class="FormField" data-template="Reference">
                    <div class="iHelp">
                    </div>
                    <label for="OperCurrencyID">
                        Currency</label><span data-attributeid="3000" data-code="US Dollar" data-token="USD"
                            id="OperCurrencyID" name="OperCurrencyID"><a class="FormLink" href="/Promys7/Administration/Currency/View/1">US
                                Dollar</a></span></div>
                <div class="FormFieldMedium" data-template="TextArea">
                    <div class="iHelp">
                    </div>
                    <label for="Brief">
                        Description</label><span data-attributeid="2979" id="Brief" name="Brief">DescriptionCPN001</span></div>
            </fieldset>
            <fieldset class="Rounded" id="MainGroup2">
                <legend>Activity Costs</legend>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;100.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperExpectedCampaignCostAmount">
                        Campaign Budge</label><span id="OperExpectedCampaignCostAmount" name="OperExpectedCampaignCostAmount">100.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;1000.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperExpectedActivitiesCostAmount">
                        Total Activity Budget</label><span id="OperExpectedActivitiesCostAmount" name="OperExpectedActivitiesCostAmount">1000.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;100.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperExpectedTotalCampaignCostAmount">
                        Total Campaign Budget</label><span id="OperExpectedTotalCampaignCostAmount" name="OperExpectedTotalCampaignCostAmount">100.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;1000.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperActualCampaignCostAmount">
                        Campaign Actual Cost</label><span id="OperActualCampaignCostAmount" name="OperActualCampaignCostAmount">1000.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;100.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperActualActivitiesCostAmount">
                        Total Activity Actual Cost</label><span id="OperActualActivitiesCostAmount" name="OperActualActivitiesCostAmount">100.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;1000.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperActualTotalCampaignCostAmount">
                        Total Campaign Actual Cost</label><span id="OperActualTotalCampaignCostAmount" name="OperActualTotalCampaignCostAmount">1000.00</span></div>
                <div class="FormField" data-fielddata="{&quot;Maximum&quot;:2147483647,&quot;Minimum&quot;:0,&quot;Places&quot;:2,&quot;Step&quot;:1,&quot;Calculations&quot;:[],&quot;InitialValue&quot;:&quot;1000.0000&quot;,&quot;Template&quot;:&quot;Decimal&quot;}"
                    data-template="Decimal">
                    <div class="iHelp">
                    </div>
                    <label for="OperExpectedRevenueAmount">
                        Expected Revenue</label><span id="OperExpectedRevenueAmount" name="OperExpectedRevenueAmount">1000.00</span></div>
            </fieldset>
        </div>
        <div class="FormSection ui-tabs-panel ui-widget-content ui-corner-bottom ui-tabs-hide"
            id="ExceptionsCampaignActivitye0777bfbab2349c59f284648a269f6c3" style="height: 253px;">
            <fieldset class="Rounded" id="CampaignActivityGroup">
                <legend>List of Activities</legend>
                <table data-function="CampaignActivityGridCampaignActivityGrid9ea40f17829f4a489067e2f1f7bd7e0bGet()"
                    data-token="CampaignActivityGrid" id="CampaignActivityGrid9ea40f17829f4a489067e2f1f7bd7e0b">
                </table>
                <div id="pCampaignActivityGrid9ea40f17829f4a489067e2f1f7bd7e0b">
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>
