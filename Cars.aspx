<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="CarRenting.Cars" %>
<asp:Content ID="Cars" ContentPlaceHolderID="MainContent" runat="server">
        <div class="d-flex flex-wrap gap-3">
         <asp:Repeater ID="CarsRepeater" OnItemDataBound="CarsRepeater_ItemDataBound" runat="server">
            <ItemTemplate>
                    <div class="card" style="width: 18rem;">
                       <img src="<%# "data:image/png;base64," + Eval("ImageBase64") %>" class="card-img-top" alt="Image" style="height:100px">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Name") %></h5>
                               <asp:Button Text="Ok" Id="selectCar" onclick="NavigateToPayment" CommandArgument='<%# Eval("Name")%>' class="btn btn-primary" runat="server"/>
                            </div>
                    </div>  
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
