using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysRpt = Crystal.Report.Component;

using Util = Vanilla.Utility.Facade.Report;

namespace Vanilla.Report.Facade.Document
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrysRpt.Data rptData = data as CrysRpt.Data;
            return new Dto
            {
                Id = rptData.Id,
                Date = rptData.Date,
                Category = rptData.Category == null ? null : new Category.Dto
                {
                    Id = rptData.Category.Id,
                    Name = rptData.Category.Name,
                    Extension = rptData.Category.Extension
                },
                DataSource = rptData.DataSource,
                Path = rptData.Path,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reportDto = dto as Dto;
            return new CrysRpt.Data
            {
                Id = reportDto.Id,
                Date = reportDto.Date,
                Category = new CrysRpt.Category.Data { Id = reportDto.Category.Id }
            };
        }

        public override void Add()
        {
            FormDto formDto = this.FormDto as FormDto;
            CrysRpt.Data rptData = this.Convert(formDto.Dto) as CrysRpt.Data;
            //ReturnObject<Boolean> retVal = (this.CreateInstance(rptData) as ICrud).Save();
            //if (retVal.Value && rptData.Id > 0)
            //{
            //    formDto.Dto.Id = rptData.Id;
            //}

            //this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public virtual void SetReportCredential()
        {
            throw new NotImplementedException();
        }

        public void Generate(DateTime date, Category.Dto reportCategory)
        {
            List<BinAff.Core.Data> reportDataList = this.CreateComponentInstance(new CrysRpt.Category.Data
            {
                Id = reportCategory.Id,
            }).GetReport(date);
            (this.FormDto as FormDto).ReportData = this.ConvertReportDataList(reportDataList);
        }

        protected virtual CrysRpt.IReport CreateComponentInstance(CrysRpt.Category.Data reportCategory)
        {
            throw new NotImplementedException();
        }

        private List<BinAff.Facade.Library.Dto> ConvertReportDataList(List<BinAff.Core.Data> reportDataList)
        {
            List<BinAff.Facade.Library.Dto> dtoList = new List<BinAff.Facade.Library.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Report.Component.Data data in reportDataList)
                {
                    dtoList.Add(this.ConvertReportData(data));
                }
            }
            return dtoList;
        }

        protected virtual BinAff.Facade.Library.Dto ConvertReportData(CrysRpt.Data data)
        {
            throw new NotImplementedException();
        }

    }

}
