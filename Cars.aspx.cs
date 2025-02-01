using Test.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace CarRenting
{
    public partial class Cars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ReturnUrl"] = Request.RawUrl;

            if (!Page.IsPostBack)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Request.QueryString["agency"] != null)
                    {
                        string agency = Request.QueryString["agency"];
                        var cars = context.Agencies.First(a => a.Name == agency).Cars;
                        CarsRepeater.DataSource = cars;
                    }
                    else
                        CarsRepeater.DataSource = context.Cars.ToList();
                    
                    CarsRepeater.DataBind();
                }
            }
        }
         protected void CarsRepeater_ItemDataBound(Object Sender,RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button selectCar = (Button)e.Item.FindControl("selectCar");
                if (Request.QueryString["agency"] == null)
                {
                    selectCar.Visible = false;
                }

                else selectCar.Visible = true;
            }
        }
        protected void NavigateToPayment(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string car = btn.CommandArgument.ToString();
            Response.Redirect($"Payment.aspx?car={car}");
        }
    }
}