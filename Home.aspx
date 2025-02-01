<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CarRenting._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
         
  <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
             
    
    <h1 style="display:flex;justify-content:center"> Book your Car</h1>

           <div class="container">
              <div class="row d-flex ">
                     <asp:DropDownList ID="cities" runat="server" CssClass="col-md-3 form-control">
                    </asp:DropDownList>
                   <asp:TextBox type="text" id="startDatePicker" class="col-md-4 form-control" CssClass="startdatepicker w-100 mr-3 ml-3" placeholder="select a date" runat="server" />
                   <asp:TextBox type="text"  class="col-md-4 form-control" id="endDatePicker" CssClass="enddatepicker w-100 mr-3 " placeholder="select a date" runat="server"/>
                   <asp:Button Text="Ok"  onclick="NavigateToAgencies" CssClass="btn btn-success" runat="server"   />
              </div>

           </div>  

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            //Initialize FlatPicker
            flatpickr(".startdatepicker", { enableTime: true, minDate: "today", defaultDate: new Date(), dateFormat: "Y-m-d H:i" });
            flatpickr(".enddatepicker", { enableTime: true, minDate: "today", defaultDate: new Date(new Date().setDate(new Date().getDate() + 1)), dateFormat: "Y-m-d H:i" });
        });
    </script>
</asp:Content>
