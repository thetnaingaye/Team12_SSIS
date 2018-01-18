﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Team12_SSIS.Exceptions;

namespace Team12_SSIS.Utility
{
    public class EmailControl : IDisposable
    {

        const string greeting = "Dear Sir/Madam, ";
        const string twoLineSpacing = "\n\n";
        const string systemGen = "This is a system generated email. Please do not reply to this email address.";
        bool success = false;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EmailService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #region Email Notifications For Store Clerk

        /*  - Disbursement Point Change
    - Collection Representative Change
    - New Purchase Order Created
    - Change in Purchase Order Status
    - New Request Form Received
    - Change in Adjustment Voucher Status*/

        /// <summary>
        /// Send a template notification to the Store Clerk when Department Rep change their preferred Collection Point.
        /// <para>Recipient email (List[String] or String),String Department Name, String Department Rep Name ,String New Disbursement Point</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <return>boolean</return>
        public bool DisburstmentPointChangeNotification(List<string> storeClerkEmailAddress, string departmentName, string collectionRepName, string newDisburstmentPoint)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    collectionRepName +
                    " has changed his/her preferred collection point to " +
                    newDisburstmentPoint +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Disburstment Point Changed Notification for " + collectionRepName;
                mail.Body = bodyMessage;
                foreach (string storeClerk in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerk);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("DisburstmentPointChangeNotification Exception\n" + e.Message);
            }
        }
        public bool DisburstmentPointChangeNotification(string storeClerkEmailAddress, string departmentName, string collectionRepName, string newDisburstmentPoint)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    collectionRepName +
                    " has changed his/her preferred collection point to " +
                    newDisburstmentPoint +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Disburstment Point Changed Notification for " + collectionRepName;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("DisburstmentPointChangeNotification Exception\n" + e.Message);
            }
        }
        /// <summary>
        /// Send a template notification to the Store Clerk when there is a change in Department Collection Representative.
        /// <para>(List[String] or String)Recipient email,String Department Name, String New Department Rep Name</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        public bool CollectionRepChangeNotification(List<string> storeClerkEmailAddress, string departmentName, string newDepartmentRepName)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    departmentName +
                    " has changed their Collection Representative to " +
                    newDepartmentRepName +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Representative for " + departmentName + " Department";
                mail.Body = bodyMessage;
                foreach (string storeClerk in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerk);
                    client.Send(mail);

                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("CollectionRepChangeNotification Exception\n" + e.Message);
            }
        }
        public bool CollectionRepChangeNotification(string storeClerkEmailAddress, string departmentName, string newDepartmentRepName)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    departmentName +
                    " has changed their Collection Representative to " +
                    newDepartmentRepName +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Representative for " + departmentName + " Department";
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("CollectionRepChangeNotification Exception\n" + e.Message);
            }
        }
        /// <summary>
        /// Send a template notification to the Store Clerk when there is a new system generated Purchase Order.
        /// <para>(List[String] or String)Recipient email,String PO number, String PO date, List of product name (optional), List of product quantity(optional)</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        public bool NewPurchaseOrderBySystemNotification(List<string> storeClerkEmailAddress, string poNumber, string dateTime, List<string> productName, List<string> orderQuantity)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string itemTable = "\nList of Item Ordered\n" +
                    "---------------------------------------------------------------\n" +
                    "Product Name" + "------------" + "Quantity" + twoLineSpacing;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by System: " + poNumber;
                int i = 0;
                foreach (string _productName in productName)
                {

                    itemTable += _productName + "------------" + orderQuantity.ElementAt(i) + "\n";
                    i++;
                }
                bodyMessage += itemTable;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderBySystemNotification Exception\n" + e.Message);
            }
        }
        public bool NewPurchaseOrderBySystemNotification(string storeClerkEmailAddress, string poNumber, string dateTime, List<string> productName, List<string> orderQuantity)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string itemTable = "\nList of Item Ordered\n" +
                    "---------------------------------------------------------------\n" +
                    "Product Name" + "------------" + "Quantity" + twoLineSpacing;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by System: " + poNumber;
                int i = 0;
                foreach (string _productName in productName)
                {

                    itemTable += _productName + "------------" + orderQuantity.ElementAt(i) + "\n";
                    i++;
                }
                itemTable += "\n" + "---------------------------------------------------------------";
                bodyMessage += itemTable;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);

                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderBySystemNotification Exception\n" + e.Message);
            }
        }
        public bool NewPurchaseOrderBySystemNotification(List<string> storeClerkEmailAddress, string poNumber, string dateTime)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by System: " + poNumber;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderBySystemNotification Exception\n" + e.Message);
            }
        }

        public bool NewPurchaseOrderBySystemNotification(string storeClerkEmailAddress, string poNumber, string dateTime)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by System: " + poNumber;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderBySystemNotification Exception\n" + e.Message);
            }
        }

        /// <summary>
        /// Send a template notification to the Store Clerk when a new Request Form is approved by Department Head.
        /// <para>(List[String] or String) Recipient email,String Department Name, String Employee Name, String Request Form Id</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        public bool NewRequestFormReceivedNotification(List<string> storeClerkEmailAddress, string departmentName, string departmentEmployee, string requestId)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    departmentEmployee +
                    " from " +
                    departmentName +
                    " has created a new Stationery Request " +
                    twoLineSpacing +
                    " Please log into SISS System to process the request." +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Stationery Request from " + departmentName + " " + requestId;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewRequestFormReceivedNotification Exception\n" + e.Message);
            }
        }
        public bool NewRequestFormReceivedNotification(string storeClerkEmailAddress, string departmentName, string departmentEmployee, string requestId)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    departmentEmployee +
                    " from " +
                    departmentName +
                    " has created a new Stationery Request " +
                    twoLineSpacing +
                    " Please log into SISS System to process the request." +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Stationery Request from " + departmentName + " " + requestId;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewRequestFormReceivedNotification Exception\n" + e.Message);
            }
        }
        /// <summary>
        /// Send a template notification to the Store Clerk when the status of Purchase Order has changed by the Store Supervisor.
        /// <para>(List[String] or String) Recipient email,String poNumber, String PO Date, String status</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        public bool ChangeInPurchaseOrderStatusNotification(List<string> storeClerkEmailAddress, string poNumber, string dateTime, string status)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Purchase Order Number " +
                    poNumber +
                    " created on " +
                    dateTime +
                    " has been " +
                    status +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Purchase Order number " + poNumber + " has been " + status;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInPurchaseOrderStatusNotification Exception\n" + e.Message);
            }

        }
        public bool ChangeInPurchaseOrderStatusNotification(string storeClerkEmailAddress, string poNumber, string dateTime, string status)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Purchase Order Number " +
                    poNumber +
                    " created on " +
                    dateTime +
                    " has been " +
                    status +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Purchase Order number " + poNumber + " has been " + status;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInPurchaseOrderStatusNotification Exception\n" + e.Message);
            }
        }
        /// <summary>
        /// Send a template notification to the Store Clerk when the status of Adjustment Voucher Request has changed by the Store Supervisor or Manager.
        /// <para>(List[String] or String)Recipient email,String Department Name, String Employee Name, String Adjustment Request Id, String status, String Remarks (optional)</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool ChangeInAdjustmentVoucherStatusNotification(List<string> storeClerkEmailAddress, string adjustmentVId, string status)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Adjustment Request for " +
                    adjustmentVId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Adjustment Voucher Request " + adjustmentVId + " has been " + status;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInAdjustmentVoucherStatus Exception\n" + e.Message);
            }
        }

        public bool ChangeInAdjustmentVoucherStatusNotification(List<string> storeClerkEmailAddress, string adjustmentVId, string status, string remarks)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Adjustment Request for " +
                    adjustmentVId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    "Comment: " +
                    twoLineSpacing +
                    remarks +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Adjustment Voucher Request " + adjustmentVId + " has been " + status;
                mail.Body = bodyMessage;
                foreach (string storeClerkEmail in storeClerkEmailAddress)
                {
                    mail.To.Add(storeClerkEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInAdjustmentVoucherStatus Exception\n" + e.Message);
            }

        }

        public bool ChangeInAdjustmentVoucherStatusNotification(string storeClerkEmailAddress, string adjustmentVId, string status)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Adjustment Request for " +
                    adjustmentVId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Adjustment Voucher Request " + adjustmentVId + " has been " + status;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);

                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInAdjustmentVoucherStatus Exception\n" + e.Message);
            }
        }

        public bool ChangeInAdjustmentVoucherStatusNotification(string storeClerkEmailAddress, string adjustmentVId, string status, string remarks)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Adjustment Request for " +
                    adjustmentVId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    "Comment: " +
                    twoLineSpacing +
                    remarks +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Adjustment Voucher Request " + adjustmentVId + " has been " + status;
                mail.Body = bodyMessage;
                mail.To.Add(storeClerkEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInAdjustmentVoucherStatus Exception\n" + e.Message);
            }

        }




        #endregion

        #region Email Notification For Store Supervisor
        /* - New Adjustment Voucher Request
           - New Purchase Order Request*/

        /// <summary>
        /// Send a template notification to the Store Supervisor when a new Adjustment Voucher Request has raised by the Store Clerk.
        /// <para>(List[String] or String) Recipient email,String Adjustment Voucher Id, String Store Clerk Name</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool NewAdjustmentVoucherRequestNotification(List<string> storeSupervisorEmailAddress, string adjustmentVId, string storeClerkName)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "New Adjustment Request " +
                    adjustmentVId +
                    " has been created by " +
                    storeClerkName +
                    twoLineSpacing +
                    "Please log into SISS to process the request." +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Pending Adjustment Voucher Request " + adjustmentVId + " created by " + storeClerkName;
                mail.Body = bodyMessage;
                foreach (string storeSupervisorEmail in storeSupervisorEmailAddress)
                {
                    mail.To.Add(storeSupervisorEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewAdjustmentVoucherRequestNotification Exception\n" + e.Message);
            }
        }
        public bool NewAdjustmentVoucherRequestNotification(string storeSupervisorEmailAddress, string adjustmentVId, string storeClerkName)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "New Adjustment Request " +
                    adjustmentVId +
                    " has been created by " +
                    storeClerkName +
                    twoLineSpacing +
                    "Please log into SISS to process the request." +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Pending Adjustment Voucher Request " + adjustmentVId + " created by " + storeClerkName;
                mail.Body = bodyMessage;
                mail.To.Add(storeSupervisorEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewAdjustmentVoucherRequestNotification Exception\n" + e.Message);
            }
        }
        /// <summary>
        /// Send a template notification to the Store Supervisor when a new Purchase Order has been raised.
        /// <para>(List[String] or String) Recipient email,String Name of PO creater, String PO number, String PO Date, List[string] product name, List[string] product quantity (optional)</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool NewPurchaseOrderForApprovalNotification(List<string> storeSupervisorEmailAddress, string poCreater, string poNumber, string dateTime, List<string> productName, List<string> orderQuantity)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string bodyEnd = twoLineSpacing + systemGen;
                string itemTable = "\nList of Item Ordered\n" +
                    "---------------------------------------------------------------\n" +
                    "Product Name" + "------------" + "Quantity" + twoLineSpacing;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by " + poCreater + " " + poNumber;
                int i = 0;
                foreach (string _productName in productName)
                {

                    itemTable += _productName + "------------" + orderQuantity.ElementAt(i) + "\n";
                    i++;
                }
                bodyMessage += itemTable;
                bodyMessage += twoLineSpacing + "Please log into SISS to process this Purchase Order request.";
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.Body = bodyMessage;
                foreach (string storeSupervisorEmail in storeSupervisorEmailAddress)
                {
                    mail.To.Add(storeSupervisorEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderForApprovalNotification Exception\n" + e.Message);
            }
        }
        public bool NewPurchaseOrderForApprovalNotification(string storeSupervisorEmailAddress, string poCreater, string poNumber, string dateTime, List<string> productName, List<string> orderQuantity)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string bodyEnd = twoLineSpacing + systemGen;
                string itemTable = "\nList of Item Ordered\n" +
                    "---------------------------------------------------------------\n" +
                    "Product Name" + "------------" + "Quantity" + twoLineSpacing;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by " + poCreater + " " + poNumber;
                int i = 0;
                foreach (string _productName in productName)
                {

                    itemTable += _productName + "------------" + orderQuantity.ElementAt(i) + "\n";
                    i++;
                }
                bodyMessage += itemTable;
                bodyMessage += twoLineSpacing + "Please log into SISS to process this Purchase Order request.";
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.Body = bodyMessage;
                mail.To.Add(storeSupervisorEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderForApprovalNotification Exception\n" + e.Message);
            }
        }
        public bool NewPurchaseOrderForApprovalNotification(List<string> storeSupervisorEmailAddress, string poCreater, string poNumber, string dateTime)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string bodyEnd = twoLineSpacing + systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by " + poCreater + " " + poNumber;
                bodyMessage += twoLineSpacing + "Please log into SISS to process this Purchase Order request.";
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.Body = bodyMessage;
                foreach (string storeSupervisorEmail in storeSupervisorEmailAddress)
                {
                    mail.To.Add(storeSupervisorEmail);
                    client.Send(mail);
                }
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderForApprovalNotification Exception\n" + e.Message);
            }
        }
        public bool NewPurchaseOrderForApprovalNotification(string storeSupervisorEmailAddress, string poCreater, string poNumber, string dateTime)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "A new Purchase Order" +
                    " (" + poNumber + ") " +
                    "has been generated on " +
                    dateTime;
                string bodyEnd = twoLineSpacing + systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "New Purchase Order Generated by " + poCreater + " " + poNumber;
                bodyMessage += twoLineSpacing + "Please log into SISS to process this Purchase Order request.";
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.Body = bodyMessage;
                mail.To.Add(storeSupervisorEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewPurchaseOrderForApprovalNotification Exception\n" + e.Message);
            }
        }

        #endregion

        #region Email Notification For Store Manager
        //Refer to NewAdjustmentVoucherRequestNotification method.
        //Nothing here...
        #endregion

        #region Email Notification for Department Employee

        /// <summary>
        /// Send a template notification to the Department Employee when the status of Stationey Request Form has been changed.
        /// <para>String Recipient email,String request id, String status, String remarks(optional)</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        public bool ChangeInStationeryRequestStatusNotification(string deptEmployeeEmailAddress, string requestId, string status)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Stationery Request for " +
                    requestId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Your Stationery Request for has been " + status;
                mail.Body = bodyMessage;
                mail.To.Add(deptEmployeeEmailAddress);
                client.Send(mail);

                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInStationeryRequestStatusNotification Exception\n" + e.Message);
            }
        }

        public bool ChangeInStationeryRequestStatusNotification(string deptEmployeeEmailAddress, string requestId, string status, string remarks)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "Stationery Request for " +
                    requestId +
                    " has been " +
                    status +
                    twoLineSpacing +
                    "Comment: " +
                    twoLineSpacing +
                    remarks +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Stationey Request has been " + status;
                mail.Body = bodyMessage;
                mail.To.Add(deptEmployeeEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("ChangeInAdjustmentVoucherStatus Exception\n" + e.Message);
            }

        }
        #endregion

        #region Email Notification For Department Representative
        /// <summary>
        /// Send a template notification to the Collection Representative when a Disbursement List is created.
        /// <para>StringRecipient email,String Collection Point, String Collection Date,List Product Name (optional), List Product Quantity (optional)</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool NewStationeryCollectionNotification(string deptRepEmailAddress, string collectionPoint, string dateTime, List<string> productName, List<string> orderQuantity)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "The stationery request for your department is ready for collection ";
                string bodyEnd = twoLineSpacing + systemGen;
                string itemTable = "\nList of Stationeries to be collected\n" +
                    "---------------------------------------------------------------\n" +
                    "Product Name" + "------------" + "Quantity";
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Stationery collection on " + dateTime + " at " + collectionPoint;
                int i = 0;
                foreach (string _productName in productName)
                {

                    itemTable += _productName + "------------" + orderQuantity.ElementAt(i);
                    i++;
                }
                bodyMessage += itemTable;
                bodyMessage += "Please make collection arragement on " + dateTime + " at " + collectionPoint;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.To.Add(deptRepEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewStationeryCollectionNotification Exception\n" + e.Message);
            }
        }

        public bool NewStationeryCollectionNotification(string deptRepEmailAddress, string collectionPoint, string dateTime)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "The stationery request for your department is ready for collection\n";
                string bodyEnd = twoLineSpacing + systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Stationery collection on " + dateTime + " at " + collectionPoint;
                bodyMessage += "Please make collection arragement on " + dateTime + " at " + collectionPoint;
                bodyMessage += twoLineSpacing + systemGen;
                mail.Body = bodyMessage;
                mail.To.Add(deptRepEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewStationeryCollectionNotification Exception\n" + e.Message);
            }
        }

        //do we need to cater for change of disbursement list information?
        #endregion

        #region Email Notification for Department Head
        /// <summary>
        /// Send a template notification to the Department Head when a new Stationery Request has been raised by an Employee.
        /// <para>String Recipient email,String request Id, String Employee Name</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool NewStationeryRequestNotification(string deptHeadEmailAddress, string requestId, string deptEmployeeName)
        {
            try
            {
                string bodyMessage = greeting +
                    twoLineSpacing +
                    "New stationery Request " +
                    requestId +
                    " has been created by " +
                    deptEmployeeName +
                    " for your approval. " +
                    twoLineSpacing +
                    "Please log into SISS to process the request." +
                    twoLineSpacing +
                    systemGen;
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.Subject = "Pending Stationery Request " + requestId + " created by " + deptEmployeeName;
                mail.Body = bodyMessage;
                mail.To.Add(deptHeadEmailAddress);
                client.Send(mail);
                success = true;
                return success;
            }
            catch (Exception e)
            {
                throw new EmailControlException("NewStationeryRequestNotification Exception\n" + e.Message);
            }
        }
        #endregion

        #region Email Notification For All
        /// <summary>
        /// Create a custom email and send to the intended recipient.
        /// <para>(List[String] or String)Recipient email,String Subject, String Body</para>
        /// <para>Returns a boolean "true" for execution success</para>
        /// </summary>
        /// <returns>boolean</returns>
        /// 
        public bool CustomEmailNotification(string recipientEmailAddress, string emailSubject, string emailBody)
        {
            SmtpClient client = new SmtpClient();
            MailMessage mail = new MailMessage();
            mail.To.Add(recipientEmailAddress);
            mail.Subject = emailSubject;
            mail.Body = emailBody;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                throw new EmailControlException("CustomEmailNotification Exception\n" + e.Message);
            }
        }

        public bool CustomEmailNotification(List<string> recipientEmailAddress, string emailSubject, string emailBody)
        {
            SmtpClient client = new SmtpClient();
            MailMessage mail = new MailMessage();
            mail.Subject = emailSubject;
            mail.Body = emailBody;
            try
            {
                foreach (string recipientEmail in recipientEmailAddress)
                {
                    mail.To.Add(recipientEmail);
                    client.Send(mail);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new EmailControlException("CustomEmailNotification Exception\n" + e.Message);
            }
        }
        #endregion

    }
}