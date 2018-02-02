using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Team12_SSIS.Supplier
{
    public class SendPurchaseOrderToSupplier
    {
        public static void SendPurchaseOrder()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            int poNumber = 1;
            double totalPrice = 1000.23;


            ReportParameter poNumberParam = new ReportParameter("PONumber", poNumber.ToString());
            ReportParameter deliverToParam = new ReportParameter("DeliverTo", "Hard Coded Deliver to");
            ReportParameter deliverAddressParam = new ReportParameter("DeliverAddress", "Heng Mui Keng");
            ReportParameter supplierNameParam = new ReportParameter("SupplierName", "SuperName");
            ReportParameter supplyDateParam = new ReportParameter("SupplyDate", DateTime.Now.Date.ToString("d"));
            ReportParameter totalPriceParam = new ReportParameter("TotalPrice", totalPrice.ToString());
            LocalReport lr = new LocalReport();
            lr.ReportPath = "C:\\PurchaseOrder.rdlc";
            lr.SetParameters(new ReportParameter[] { poNumberParam, deliverToParam, deliverAddressParam, supplierNameParam, supplyDateParam, totalPriceParam });



            SA45Team12ADDataSetPOTableAdapters.PurchaseOrderReportTableAdapter ta = new SA45Team12ADDataSetPOTableAdapters.PurchaseOrderReportTableAdapter();
            SA45Team12ADDataSetPO.PurchaseOrderReportDataTable dt = ta.GetData(1);
            ReportDataSource ds = new ReportDataSource("PurchaseOrderDocument", (IEnumerable)dt);
            lr.DataSources.Add(ds);

            byte[] bytes = lr.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            MemoryStream s = new MemoryStream(bytes);
            s.Seek(0, SeekOrigin.Begin);
            Attachment a = new Attachment(s, "PurchaseOrder" + poNumber.ToString() + ".pdf");

            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            message.Body = "Also testing";
            message.Subject = "Test";
            message.To.Add("sa45team12ssis+test@gmail.com");
            message.Attachments.Add(a);
            client.Send(message);

        }
    }
}