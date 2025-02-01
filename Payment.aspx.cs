using CarRenting.Entites;
using System;
using System.Linq;
using Test.Models;

namespace Test
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SchudleStartTime.Text=Session["SchudleStartTime"].ToString();
            SchudleEndTime.Text=Session["SchudleEndTime"].ToString();

            string agency = Session["agency"].ToString();
            string car = Request.QueryString["car"];

            using(var context = ApplicationDbContext.Create())
            {
                Car vehicule =context.Cars.First(c => c.Name == car);
                CarName.Text = vehicule.Name;
                AgencyName.Text = agency;
                ModelName.Text = vehicule.Model;
                Price.Text = vehicule.Price.ToString();
                Speed.Text = vehicule.Speed.ToString();
                carImage.ImageUrl = "data:image/png;base64," + vehicule.ImageBase64;
            }
        }

        protected void DisplaySuccessMessage(object sender, EventArgs e)
        {
            PaymentSuccess.Text = "Thank you for paying your booking";
        }
    }
}