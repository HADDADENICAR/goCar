using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using Test.Models;

namespace CarRenting
{
    public partial class Agencies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ReturnUrl"] = Request.RawUrl;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["city"] != null)
                {
                    List<Entites.Agency> agencies = GetOpenAgencies();

                    int cityId = int.Parse(Request.QueryString["city"]);

                   AgenciesRepeater.DataSource = agencies.Where(a => a.City.Id == cityId)
                                                                       .ToList();
                }
                else
                    using (var context = ApplicationDbContext.Create())
                    {
                        AgenciesRepeater.DataSource = context.Agencies
                                                             .Include(a =>a.Week)
                                                             .Include("Week.Weekdays")
                                                             .ToList();
                    }

                AgenciesRepeater.DataBind();
            }
        }
        List<Entites.Agency> GetOpenAgencies()
        {
            DateTime startDate;
            DateTime endDate;
            DateTime.TryParse(Session["SchudleStartTime"].ToString(), out startDate);
            DateTime.TryParse(Session["SchudleEndTime"].ToString(), out endDate);

            if (startDate >= endDate) return Enumerable.Empty<Entites.Agency>().ToList();

            using (var context = ApplicationDbContext.Create())
            {
                var openAgenciesAtStart = context.Agencies
                                                 .Where(a => a.Week.WeekDays.Any(d=>d.Day == startDate.DayOfWeek.ToString() && d.StartTime.Hours<= startDate.Hour && d.EndTime.Hours>startDate.Hour))
                                                 .Include(a =>a.City)
                                                 .ToList();

                var openAgenciesAtEnd = context.Agencies
                                                 .Where(a => a.Week.WeekDays.Any(d=>d.Day == startDate.DayOfWeek.ToString() && d.StartTime.Hours<= startDate.Hour && d.EndTime.Hours>startDate.Hour))
                                                 .Include(a=>a.City)
                                                 .ToList();


                return openAgenciesAtStart.Union(openAgenciesAtEnd).ToList();
            }
        }
        protected void AgencyRepeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button selectAgency = (Button)e.Item.FindControl("selectAgency");
                if (Request.QueryString["city"] == null)
                {
                    selectAgency.Visible = false;
                }

                else selectAgency.Visible = true;
            }
        }

        protected void NavigateToCars(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string agency = btn.CommandArgument.ToString();
            Session["agency"] = agency;
            Response.Redirect($"Cars.aspx?agency={agency}");
        }
    }
}