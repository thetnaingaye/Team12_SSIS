using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Khair Line 15 to 315
    //Chang Siang Line 316 to 616
    //Jaining Line 617 to 917
    //Pradeep 1218 to 1518
    // Line 1519 to 1820
    public class PurchasingLogic
    {











































































































































































































































































































//This method Returns a list of PO details for Goods Receipt
        public List<PORecordDetail> GetPurchaseOrdersForGR(int POnumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                //Get a existing list of Order details
                List<PORecordDetail> poDetailList = ctx.PORecordDetails.Where(x => x.PONumber == POnumber).ToList();
                //fresh list to record updated list of Order details
                List<PORecordDetail> poDetailListWithGR = new List<PORecordDetail>();
                //Create a joined table GoodReceipt with GoodsReceiptDetails to check if the item has existing GR record
                var grRecords = ctx.GoodReceipts.Join(ctx.GoodReceiptDetails,
                    gr => gr.GRNumber,
                    grd => grd.GRNumber,
                    (gr, grd) => new
                    {
                        PONumber = gr.PONumber,
                        ItemID = grd.ItemID,
                        Quantity = grd.Quantity,
                        GRNumber = gr.GRNumber,
                    }).Where(x => x.PONumber == POnumber).ToList();

                //If there is no existing GR record for this PO number, return the original PO Detail list
                if (grRecords.Count == 0)
                {
                    return poDetailList;
                }
                //If there is existing GR record for the PO, check for remaiaing GR quantity
                foreach (PORecordDetail orderedItem in poDetailList)
                {
                    //Add the updated Order detail into the fresh list.
                    PORecordDetail prd = CheckForGRQuantity(grRecords, orderedItem);
                    if (prd.Quantity > 0)
                    {
                        poDetailListWithGR.Add(prd);
                    }

                }
                //Return the Order list that has the updated reamining quantity.
                return poDetailListWithGR;
            }
        }             

        private PORecordDetail CheckForGRQuantity(dynamic grRecords, PORecordDetail orderedItem)
        {
            //for each GR record, check if the ItemID matches with the Order item ItemID
            foreach (var received in grRecords)
            {
                if (orderedItem.ItemID == received.ItemID)
                {
                    //Minus ordered quantity with received quantity
                    int qty = (int) orderedItem.Quantity - (int)received.Quantity;
                    orderedItem.Quantity = qty;                    
                }
            }
            return orderedItem;
        }

        //Method for Posting GR
        public int CreateGoodsReceipt(DateTime dateProcessed, int poNumber, string receivedBy, string doNumber)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                GoodReceipt goodReceipt = new GoodReceipt
                {
                    PONumber = poNumber,
                    ReceivedBy = receivedBy,
                    DateProcessed = dateProcessed,
                    DONumber = doNumber
                };
                ctx.GoodReceipts.Add(goodReceipt);
                ctx.SaveChanges();
                return goodReceipt.GRNumber;
            }
            
        }

        public PORecord GetPORecords (int poNumber)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
                return ctx.PORecords.FirstOrDefault(x => x.PONumber == poNumber);
        }

        public void CreateGoodsReceiptDetails(int grNumber, string itemID, int quantity, string uom, string remarks)
        {
            GoodReceiptDetail grd = new GoodReceiptDetail();
            grd.GRNumber = grNumber;
            grd.ItemID = itemID;
            grd.Quantity = quantity;
            grd.UOM = uom;
            grd.Remarks = remarks;
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.GoodReceiptDetails.Add(grd);
                ctx.SaveChanges();
            }
        }

        public GoodReceipt GetGoodsReceipt(int goodReceiptNumber)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.GoodReceipts.FirstOrDefault(x => x.GRNumber == goodReceiptNumber);
            }
        }

        public List<GoodReceiptDetail> GetGoodsReceiptDetails(int goodReceiptNumber)
        {
            using(SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.GoodReceiptDetails.Where(x => x.GRNumber == goodReceiptNumber).ToList();
            }
        }






    }
}