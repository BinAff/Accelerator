﻿using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysRpt = Crystal.Report.Component;

using Util = Vanilla.Utility.Facade.Report;

namespace Vanilla.Report.Facade.Document
{

    public abstract class Server : BinAff.Facade.Library.Server
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

        public abstract override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto);

        public override void Add()
        {
            FormDto formDto = this.FormDto as FormDto;
            CrysRpt.Data rptData = this.Convert(formDto.Dto) as CrysRpt.Data;
            ReturnObject<Boolean> retVal = (this.CreateComponentInstance(rptData) as ICrud).Save();
            if (retVal.Value && rptData.Id > 0)
            {
                formDto.Dto.Id = rptData.Id;
            }

            this.DisplayMessageList = retVal.GetMessage((this.IsError = retVal.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public void SetCategory(Category.Dto categoy)
        {
            (this.FormDto as FormDto).Dto.Category = categoy;
        }

        public void SetDate(DateTime date)
        {
            (this.FormDto as FormDto).Dto.Date = date;
        }

        public Dto GetModule()
        {
            return (this.FormDto as FormDto).Dto;
        }

        public List<BinAff.Facade.Library.Dto> Generate(DateTime date, Category.Dto reportCategory)
        {
            CrysRpt.IReport server = this.CreateComponentInstance(new CrysRpt.Category.Data
            {
                Id = reportCategory.Id,
            });

            List<BinAff.Core.Data> reportDataList = server.GetReport(date);
            (this.FormDto as FormDto).Dto.ReportName = server.GetReportName();
            return (this.FormDto as FormDto).ReportData = this.ConvertReportDataList(reportDataList, server.SetStartEnd());
        }

        public abstract Dto SetReportCredential();

        protected virtual CrysRpt.IReport CreateComponentInstance(CrysRpt.Category.Data reportCategory)
        {
            throw new NotImplementedException();
        }

        protected abstract ICrud CreateComponentInstance(CrysRpt.Data rptData);

        private List<BinAff.Facade.Library.Dto> ConvertReportDataList(List<BinAff.Core.Data> reportDataList, CrysRpt.Data parameters)
        {
            List<BinAff.Facade.Library.Dto> dtoList = new List<BinAff.Facade.Library.Dto>();
            if (reportDataList != null && reportDataList.Count > 0)
            {
                foreach (Crystal.Report.Component.Data data in reportDataList)
                {
                    Vanilla.Report.Facade.Document.Dto dto = this.ConvertReportData(data) as Vanilla.Report.Facade.Document.Dto;
                    dto.Start = parameters.Start;
                    dto.End = parameters.End;
                    dtoList.Add(dto);
                }
            }
            return dtoList;
        }

        protected abstract Vanilla.Report.Facade.Document.Dto ConvertReportData(CrysRpt.Data data);

    }

}
