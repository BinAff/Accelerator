using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Invoice.Component.Taxation
{

    public class Server : BinAff.Core.Observer.SubjectCrud, ITaxation
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Taxation";
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

        protected override void CreateChildren()
        {
            base.AddChildren(new Slab.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = false,
            }, ((Data)base.Data).SlabList);
        }

        ReturnObject<List<BinAff.Core.Data>> ITaxation.ReadLodgeTaxation(Double value)
        {
            ReturnObject<List<BinAff.Core.Data>> ret = base.ReadAll();
            if (ret.Value != null && ret.Value.Count > 0)
            {
                foreach (Data tax in ret.Value)
                {
                    this.CalculateTax(tax, value);
                }
            }
            return ret;
        }

        private void CalculateTax(Data data, Double value)
        {
            if (data.SlabList != null && data.SlabList.Count > 0)
            {
                List<BinAff.Core.Data> currentSlabList = data.SlabList.FindAll((p) =>
                {
                    return (p as Slab.Data).Start <= DateTime.Now && (p as Slab.Data).End >= DateTime.Now;
                });
                if (currentSlabList != null && currentSlabList.Count > 0)
                {
                    currentSlabList.Sort(new Comparison<BinAff.Core.Data>((p1, p2) =>
                    {
                        if ((p1 as Slab.Data).Limit < (p2 as Slab.Data).Limit)
                        {
                            return -1;
                        }
                        else if ((p1 as Slab.Data).Limit > (p2 as Slab.Data).Limit)
                        {
                            return 1;
                        }
                        return 0;
                    }));
                    data.Amount = 0;
                    foreach (Slab.Data slab in currentSlabList)
                    {
                        if (value < slab.Limit)
                        {
                            break;
                        }
                        else
                        {
                            data.Amount = slab.Amount;
                        }
                    }
                }
            }
        }

        ReturnObject<Double> ITaxation.Calculate(Double amount)
        {
            Data data = base.Data as Data;
            return (data == null) ?
                new ReturnObject<Double>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Tax is null.", Message.Type.Error),
                    }
                } :
                new ReturnObject<Double>
                {
                    Value = (data.IsPercentage) ? amount * (data.Amount / 100) : data.Amount,
                };
        }

    }

}
