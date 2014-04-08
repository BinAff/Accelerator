
using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component.Report
{
    public class Server : Crystal.Report.Component.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Report";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }
        
        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }
        
        public override List<BinAff.Core.Data> GetDailyReport(DateTime date)
        {
            return ((Dao)this.DataAccess).GetSalesData(date, date);
        }

        public override List<BinAff.Core.Data> GetWeeklyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public override List<BinAff.Core.Data> GetMonthlyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public override List<BinAff.Core.Data> GetQuarterlyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public override List<BinAff.Core.Data> GetYearlyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }
    }
}
