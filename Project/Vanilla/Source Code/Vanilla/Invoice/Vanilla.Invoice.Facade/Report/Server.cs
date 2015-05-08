using System;

using BinAff.Core;

using CrysInvRpt = Crystal.Accountant.Component.Invoice.Report;
using CrysRpt = Crystal.Report.Component;
//using Crystal.Navigator.Component.Artifact.Observer;

namespace Vanilla.Accountant.Facade.Report
{

    public class Server : Vanilla.Report.Facade.Document.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrysInvRpt.Data
            {
                Id = reportDto.Id,
                Date = reportDto.Date,
                Category = new CrysRpt.Category.Data
                {
                    Id = reportDto.Category.Id
                },
            };
        }

        protected override CrysRpt.IReport CreateComponentInstance(CrysRpt.Category.Data reportCategory)
        {
            return new CrysInvRpt.Server(new CrysInvRpt.Data
            {
                Category = reportCategory,
            });
        }

        protected override ICrud CreateComponentInstance(CrysRpt.Data rptData)
        {
            return new CrysInvRpt.Server(rptData as CrysInvRpt.Data);
        }

        public override Vanilla.Report.Facade.Document.Dto SetReportCredential()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Dto;
            dto.DataSource = "Sales";

            //Path is wrong
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("Vanilla"));
            path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Report\" + dto.ReportName;

            dto.ReportFilePath = path;
            return dto;
        }

        protected override Vanilla.Report.Facade.Document.Dto ConvertReportData(CrysRpt.Data data)
        {
            CrysInvRpt.Data reportData = data as CrysInvRpt.Data;
            return new Dto
            {
                Id = reportData.Id,
                InvoiceNumber = reportData.InvoiceNumber,
                InvoiceDate = reportData.InvoiceDate,
                Amount = reportData.Amount,
                AmountPaid = reportData.AmountPaid,
                Discount = reportData.Discount,
                Tax = reportData.Tax,

                SellerName = reportData.SellerName,
                SellerAddress = reportData.SellerAddress,
                SellerContactNo = reportData.SellerContactNo,
                SellerEmail = reportData.SellerEmail,
                SellerLicence = reportData.SellerLicence,

                BuyerName = reportData.BuyerName,
                BuyerAddress = reportData.BuyerAddress,
                BuyerContactNo = reportData.BuyerContactNo,
            };
        }

        //protected override DocumentComponent GetComponentServer()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override string GetComponentDataType()
        //{
        //    throw new NotImplementedException();
        //}

    }

}
