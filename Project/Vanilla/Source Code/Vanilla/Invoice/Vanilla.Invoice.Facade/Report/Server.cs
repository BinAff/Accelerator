
using BinAff.Core;
using CrystalInvoiceReport = Crystal.Invoice.Component.Report;

namespace Vanilla.Invoice.Facade.Report
{
    public class Server : BinAff.Facade.Library.Server
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
            Crystal.Invoice.Component.Report.Data invoiceReportData = data as Crystal.Invoice.Component.Report.Data;
            return new Dto
            {
                Id = invoiceReportData.Id,
                fromDate = invoiceReportData.FromDate,
                toDate = invoiceReportData.ToDate,
                category = invoiceReportData.category == null ? null : new Vanilla.Report.Facade.Category.Dto{ Id = invoiceReportData.category.Id }
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrystalInvoiceReport.Data
            {
                FromDate = reportDto.fromDate,
                ToDate = reportDto.toDate,
                category = new Crystal.Report.Component.Category.Data { Id = reportDto.category.Id }
            };
        }

        public override void Add()
        {            
            FormDto formDto = this.FormDto as FormDto;

            CrystalInvoiceReport.Data invoiceReportData = this.Convert(formDto.dto) as CrystalInvoiceReport.Data;
            //CrystalInvoiceReport.Data invoiceReportData = new CrystalInvoiceReport.Data 
            //{
            //    FromDate = formDto.dto.fromDate,
            //    ToDate = formDto.dto.toDate 
            //};
            ICrud crud = new CrystalInvoiceReport.Server(invoiceReportData);
            ReturnObject<bool> retVal = crud.Save();

            if (retVal.Value && invoiceReportData.Id > 0)
                formDto.dto.Id = invoiceReportData.Id;

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);           
        }
    }
}
