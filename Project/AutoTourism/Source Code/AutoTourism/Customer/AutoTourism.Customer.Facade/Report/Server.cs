﻿using System.Collections.Generic;
using BinAff.Core;
using CrystalCustomerReport = Crystal.Customer.Component.Report;
using CrystalReport = Crystal.Report.Component;


namespace AutoTourism.Customer.Facade.Report
{
    public class Server : BinAff.Facade.Library.Server, IReport
    {
        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            //throw new NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrystalCustomerReport.Data invoiceReportData = data as CrystalCustomerReport.Data;
            return new Dto
            {
                Id = invoiceReportData.Id,
                date = invoiceReportData.Date,               
                category = invoiceReportData.category == null ? null : new Vanilla.Report.Facade.Category.Dto{ Id = invoiceReportData.category.Id }
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalCustomerReport.Data
            {
                Date = reportDto.date,               
                category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalCustomerReport.Data customerReportData = this.Convert(formDto.dto) as CrystalCustomerReport.Data;
            ICrud crud = new CrystalCustomerReport.Server(customerReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && customerReportData.Id > 0)
                formDto.dto.Id = customerReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }

        List<Facade.Dto> IReport.GetDailyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetDailyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<Facade.Dto> IReport.GetWeeklyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetWeeklyReport(date);
            return this.GetCustomerData(reportDataList);
        }
                
        List<Facade.Dto> IReport.GetMonthlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetMonthlyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<Facade.Dto> IReport.GetQuarterlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetQuarterlyReport(date);
            return this.GetCustomerData(reportDataList);
        }

        List<Facade.Dto> IReport.GetYearlyReport(System.DateTime date)
        {
            CrystalReport.IReport report = new CrystalCustomerReport.Server(null);
            List<BinAff.Core.Data> reportDataList = report.GetYearlyReport(date);
            return this.GetCustomerData(reportDataList);
        }
                
        private List<Facade.Dto> GetCustomerData(List<BinAff.Core.Data> reportDataList)
        {
            List<Facade.Dto> customerList = new List<Facade.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Customer.Component.Data data in reportDataList)
                {
                    customerList.Add(new Facade.Dto
                    {
                        Id = data.Id,
                     
                        //date = data.Date,
                        //invoiceNumber = data.InvoiceNumber,
                        //seller = data.Seller == null ? null : new Facade.Seller.Dto
                        //{
                        //    Name = data.Seller.Name,
                        //    Address = data.Seller.Address,
                        //    ContactNumber = data.Seller.ContactNumber,
                        //    Email = data.Seller.Email,
                        //    Liscence = data.Seller.Liscence
                        //},
                        //buyer = data.Buyer == null ? null : new Facade.Buyer.Dto
                        //{
                        //    Name = data.Buyer.Name,
                        //    Address = data.Buyer.Address,
                        //    ContactNumber = data.Buyer.ContactNumber,
                        //    Email = data.Buyer.Email
                        //}
                    });
                }
            }
            return customerList;
        }





        
    }
}
