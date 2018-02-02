using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.StoreClerk
{
    public partial class ForecastReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Auto-populate the date for the date time picker - Populate the earliest allowed date
                DateTime earliestDate = new DateTime(2014, 1, 1);
                DateFrom.Value = earliestDate.ToString("yyyy-MM-dd");
                DateTime currentDate = DateTime.Now.AddDays(-9);
                DateTo.Value = currentDate.ToString("yyyy-MM-dd");
                LblItemDesc.Text = "Please select an item.";
            }
            
        }

        // Searching for the item...and populating our report
        protected void BtnSubmit1_Click(object sender, EventArgs e)
        {
            Search();
        }


        // Auto search when you type
        protected void inputValue_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string input = inputValue.Text;
            int numvalue = 0;
            bool parsed = Int32.TryParse(input, out numvalue);
            bool errors = false;

            // Check for any empty or incorrect format for the input including no pure numbers
            if (!String.IsNullOrWhiteSpace(input) && !parsed)
            {
                // Retrieving our value from the search bar
                var temp = InventoryLogic.SearchItemForReport(inputValue.Text);

                if (temp != null)
                {
                    // Check if discontinued
                    bool check = InventoryLogic.CheckIfDiscontinued(temp.ItemID);

                    if (!check)
                    {
                        LblSelectedItem.Visible = true;
                        LblItemDesc.Text = temp.Description;
                        LblItemID.Text = temp.ItemID;
                        LblSelectNumber.Visible = true;
                        DdlNoForeacast.Visible = true;
                        LblSelectType.Visible = true;
                        DdlTypeChart.Visible = true;
                        LblDateFrom.Visible = true;
                        LblDateTo.Visible = true;
                        BtnGenerate.Visible = true;
                        DateFrom.Visible = true;
                        DateTo.Visible = true;
                    }
                    //else errors = true;
                }
                else errors = true;
            }
            else errors = true;

            if (errors)
            {
                LblSelectedItem.Visible = false;
                LblItemDesc.Text = "Item not found.";
                LblItemID.Text = "";
                LblSelectNumber.Visible = false;
                DdlNoForeacast.Visible = false;
                LblSelectType.Visible = false;
                DdlTypeChart.Visible = false;
                LblDateFrom.Visible = false;
                LblDateTo.Visible = false;
                BtnGenerate.Visible = false;
                DateFrom.Visible = false;
                DateTo.Visible = false;
            }
        }

        // This will retrieve all the necessary values and use it to generate our report
        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            // Resets all controls to default first
            LblHeader.Visible = false;
            LblErrorMsg.Text = "";
            LblErrorMsg.Visible = false;

            // Declare our attr to perform our validation
            bool anyErrors = false;

            // Retrieve Item id
            string itemID = LblItemID.Text;

            // Retrieve both of our dates
            string temp1 = DateFrom.Value;
            DateTime dateFrom = DateTime.ParseExact(temp1, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            string temp2 = DateTo.Value;
            DateTime dateTo = DateTime.ParseExact(temp2, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


            // Gotta perform our server-side validation here...
            // Ensure that dateFrom is before dateTo
            if (dateTo < dateFrom)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "Error. Ensure that the date selected is in the right order.";
                anyErrors = true;
            }
            //Ensure that dateFrom cannot be below Jan 1st 2014 cos no data for it
            if (dateFrom.Year < 2014 && !anyErrors)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "Error. No data found before 2014.";
                anyErrors = true;
            }
            // Ensure that dateTo cannot be beyond the latest date in the actual data table
            bool check = ReportLogic.CheckIfBeyondLatestData(dateTo);
            if (!check && !anyErrors)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "Error. No data beyond the selected date.";
                anyErrors = true;
            }
            // Ensure that its 6 months apart
            DateTime tempDate = dateFrom.AddMonths(6);
            if (tempDate > dateTo && !anyErrors)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "Error. Period selected must be at least 6 months apart.";
                anyErrors = true;
            }


            // If no errors, run our main logic
            if (!String.IsNullOrWhiteSpace(itemID) && !anyErrors)
            {
                // Retrieve our number of periods
                int numPeriods = Convert.ToInt32(DdlNoForeacast.SelectedItem.Value);

                // Retrieve our type of chart to generate
                int typeOfChart = Convert.ToInt32(DdlTypeChart.SelectedItem.Value);

                // Pass our value to the method in the biz logic side
                ReportLogic.GetChart(itemID, dateFrom, dateTo, numPeriods, typeOfChart);


                // Populating our Images
                ImgChart.Visible = true;
                ImgChart.ImageUrl = "~/images/Charts/chart1.png" + "?time=" + DateTime.Now.ToString();
                ImgTableResult.Visible = true;
                ImgTableResult.ImageUrl = "~/images/Charts/tableResults.png" + "?time=" + DateTime.Now.ToString();
                ImgTableAccuracy.Visible = true;
                ImgTableAccuracy.ImageUrl = "~/images/Charts/tableAccuracy.png" + "?time=" + DateTime.Now.ToString();
                ImgTableModel.Visible = true;
                ImgTableModel.ImageUrl = "~/images/Charts/tableModel.png" + "?time=" + DateTime.Now.ToString();


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
                LblAccuracy.Visible = true;
                LblModel.Visible = true;
            }

            // Updating the UpdatePanel
            UpdatePanelChart.Update();
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
    }
}