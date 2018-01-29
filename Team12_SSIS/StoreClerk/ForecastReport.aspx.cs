using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.StoreClerk
{
    public partial class ForecastReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieving our value from the search bar
            string temp = inputValue.Value;

            // Setting the value back to our search bar
            inputValue.Value = temp;
        }

        protected void BtnSubmit1_Click(object sender, EventArgs e)
        {
            string itemID = "C006";

            // Retrieving our value from the search bar
            //string temp = Request.Form["inputValue"];
            string temp = inputValue.Value;


            // Pass our value to the method in the biz logic side
            //ReportLogic.GetChart(itemID);                                 // Remove this hardcoded value

            // Populating our Image
            ImgChart.Visible = true;
            //ImgChart.ImageUrl = "C:/inetpub/wwwroot/Team12_SSIS/RScripts/Charts/Chart.png";
            //ImgChart.ImageUrl = "~/RScripts/Charts/chart1.png";

            // Populating our GridView
            GridViewForecastList.Visible = true;
            GridViewForecastList.DataSource = ReportLogic.RetrieveForecastedData(itemID);
            GridViewForecastList.DataBind();

            // Populating misc controls
            LblHeader.Visible = true;
            LblChartHeader.Visible = true;
            LblExpectedDemand.Visible = true;
            var item = InventoryLogic.FindItemByItemID(itemID);
            LblCode.Visible = true;
            LblItemCode.Visible = true;
            LblItemCode.Text = item.ItemID;
            LblDescription.Visible = true;
            LblItemDescription.Visible = true;
            LblItemDescription.Text = item.Description;
            LblCategory.Visible = true;
            LblItemCategory.Visible = true;
            LblItemCategory.Text = InventoryLogic.GetCatalogueName(item.CategoryID);
            BtnPrint.Visible = true;


            // Updating the UpdatePanel
            UpdatePanelChart.Update();
        }
    }
}