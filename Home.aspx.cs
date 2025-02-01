using System;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using Test.Models;
using CarRenting.Entites;
using System.IO;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CarRenting
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ReturnUrl"] = Request.RawUrl;
          
            if (Request.QueryString["Logout"] == "true")
            {
                UserLogout();
                Response.Redirect("Home.aspx");
            }

            if (!Page.IsPostBack)
            {
                using (var context = ApplicationDbContext.Create())
                {
                    cities.DataSource = context.Cities.ToList();
                    cities.DataTextField = "Name";
                    cities.DataValueField = "Id";
                    cities.DataBind();
                }
            }
        }
   
        protected void NavigateToAgencies(object sender, EventArgs e)
        {
            string cityId = cities.SelectedValue;
            Session["SchudleStartTime"] = startDatePicker.Text;
            Session["SchudleEndTime"] = endDatePicker.Text;

            Response.Redirect($"Agencies.aspx?city={cityId}");
        }
         void UserLogout()
        {
            Session.Clear();
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}