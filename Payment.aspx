<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Test.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .paymentGrid {
            display: flex;
            flex: 1fr 2fr;
            grid-column-gap: 2px;
        }
    </style>
    <div class="paymentGrid">
        <div id="details">
            <p>
                This car is <asp:Label ID="CarName" runat="server"></asp:Label> in agency <asp:Label ID="AgencyName" runat="server"/> , Model <asp:Label Id="ModelName" Style="color: green" runat="server"/>,with max speed of <asp:Label ID="Speed" Style="color: green" runat="server"/> kmh, the price for renting this car is <asp:Label ID="Price" Style="color: green" runat="server"></asp:Label>$
                you have selected this car for the range <asp:Label ID="SchudleStartTime" Style="color: red" runat="server"/>, <asp:Label ID="SchudleEndTime" Style="color: red" runat="server"/>
            </p>
        </div>
        <asp:Image ID="carImage" runat="server"  style ="width:80%"/>
    </div>
    <div class="d-flex justify-content-center align-items-center">
        <asp:Button Text="Payment" runat="server" OnClick="DisplaySuccessMessage" />
    </div>
    <div class="d-flex justify-content-center ">
        <asp:Label ID="PaymentSuccess" Style="color: green" runat="server"></asp:Label>
    </div>
</asp:Content>
