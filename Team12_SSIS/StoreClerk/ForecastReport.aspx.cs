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

            // Auto-populate the date for the date time picker
            DateTime earliestTime = new DateTime(2014, 1, 1);
            DateFrom.Value = earliestTime.ToString("yyyy-MM-dd");
            DateTo.Value = DateTime.Now.ToString("yyyy-MM-dd");

            if (IsPostBack)
            {
                string str = DateFrom.Value;
                DateTime dt = DateTime.ParseExact(str, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                inputValue.Value = dt.ToString();
            }
        }

        // Searching for the item...and populating our report
        protected void BtnSubmit1_Click(object sender, EventArgs e)
        {
            // Retrieving our value from the search bar
            string itemID = inputValue.Value;

            // Search....

        }

        // Set all controls to default
        protected void ResetControls()
        {
            LblHeader.Visible = false;
            LblChartHeader.Visible = false;
            LblExpectedDemand.Visible = false;
            LblCode.Visible = false;
            LblItemCode.Visible = false;
            LblItemCode.Text = null;
            LblDescription.Visible = false;
            LblItemDescription.Visible = false;
            LblItemDescription.Text = null;
            LblCategory.Visible = false;
            LblItemCategory.Visible = false;
            LblItemCategory.Text = null;
            BtnPrint.Visible = false;
        }

        // This will retrieve all the necessary values and use it to generate our report
        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            // Resets all controls to default first
            LblHeader.Visible = false;

            // Gotta perform validation here......................


            // Retrieve Item id
            string itemID = LblItemID.Text;
            itemID = "C006";

            // Retrieve both of our dates
            string temp1 = DateFrom.Value;
            DateTime dateFrom = DateTime.ParseExact(temp1, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            string temp2 = DateTo.Value;
            DateTime dateTo = DateTime.ParseExact(temp2, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


            // Pass our value to the method in the biz logic side
            ReportLogic.GetChart(itemID, dateFrom, dateTo);

            // Populating our Images
            ImgChart.Visible = true;
            ImgChart.ImageUrl = "~/images/Charts/chart1.png";
            ImgTableResult.Visible = true;
            ImgTableResult.ImageUrl = "~/images/Charts/tableResults.png";
            ImgTableAccuracy.Visible = true;
            ImgTableAccuracy.ImageUrl = "~/images/Charts/tableAccuracy.png";
            ImgTableModel.Visible = true;
            ImgTableModel.ImageUrl = "~/images/Charts/tableModel.png";

            // Populating our GridView
            //GridViewForecastList.Visible = true;
            //GridViewForecastList.DataSource = ReportLogic.RetrieveForecastedData(itemID);
            //GridViewForecastList.DataBind();

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