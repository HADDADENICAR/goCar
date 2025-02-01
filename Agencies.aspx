<%@ Page Title="Agenecies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agencies.aspx.cs" Inherits="CarRenting.Agencies" %>
<asp:Content ID="AgenciesContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="d-flex flex-wrap gap-3">
         <asp:Repeater ID="AgenciesRepeater" OnItemDataBound="AgencyRepeater_ItemDataBound" runat="server">
            <ItemTemplate>
                    <div class="card" style="width: 18rem;">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Name") %></h5>
                            <p class="card-text">
                              <asp:Repeater ID="calendar" DataSource='<%# Eval("Week.WeekDays") %>' runat="server">
                                  <ItemTemplate>
                                   <div class="d-flex">
                                      <%# Eval("Day") %>:  <%# Eval("StartTime.Hours","{0:D2}") %>:<%# Eval("StartTime.Minutes","{0:D2}") %> - <%# Eval("EndTime.Hours","{0:D2}")%>:<%# Eval("EndTime.Minutes","{0:D2}")%>
                                    </div> 
                                  </ItemTemplate>
                              </asp:Repeater>   
                            </p>
                            <asp:Button Text="Ok" runat="server" ID="selectAgency" OnClick="NavigateToCars" CommandArgument='<%# Eval("Name")%>' class="btn btn-primary"/>
                        </div>
                    </div>  
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
