using System;
using System.Collections.Generic;
using BinAff.Core;

using CrystalCustomer = Crystal.Customer.Component;

namespace Vanilla.Invoice.Facade
{
    public class Server : BinAff.Facade.Library.Server
    {
        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.paymentTypeList = this.ReadAllPaymentType();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            return new Data();
            //Dto invoiceDto = dto as Dto;

            //return new Crystal.Invoice.Component.Data()
            //{
            //    InvoiceNumber = invoiceDto.invoiceNumber,
            //    Advance = invoiceDto.advance,
            //    Discount = invoiceDto.discount,
            //    Date = System.DateTime.Now,
            //    Seller = this.GetSeller(invoiceDto.seller),
            //    Buyer = this.GetBuyer(invoiceDto.buyer),
            //    LineItem = this.GetLineItem(invoiceDto.productList),
            //    Taxation = this.GetTaxation(invoiceDto.taxationList),
            //    Payment = this.GetPayments(invoiceDto.paymentList)
            //};
        }

        public override void Add()
        {
            //AutoTourism.Component.Customer.Data autoCustomer = new AutoTourism.Component.Customer.Data
            //{
            //    Invoice = new Crystal.Invoice.Component.InvoiceContainer.Data
            //    {
            //        Active = this.Convert((this.FormDto as FormDto).dto) as CrystalCustomer.Action.Data
            //    }
            //};

            //CrystalCustomer.ICustomer customer = new AutoTourism.Component.Customer.Server(autoCustomer);
            //ReturnObject<Boolean> ret = customer.GenerateInvoice();

            //this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);             
        }

        private List<Payment.Type.Dto> ReadAllPaymentType()
        {
            List<Payment.Type.Dto> paymentList = new List<Payment.Type.Dto>();
            ICrud crud = new Crystal.Invoice.Component.Payment.Type.Server(null);
            ReturnObject<List<Data>> paymentDataList = crud.ReadAll();

            if (paymentDataList != null && paymentDataList.Value != null && paymentDataList.Value.Count > 0)
            {
                foreach (BinAff.Core.Data data in paymentDataList.Value)
                {
                    Crystal.Invoice.Component.Payment.Type.Data typeData = data as Crystal.Invoice.Component.Payment.Type.Data;
                    paymentList.Add(new Payment.Type.Dto { 
                        Id = typeData.Id,
                        Name = typeData.Name
                    });
                }
            }
            return paymentList;
        }

        //private Crystal.Invoice.Component.Seller GetSeller(Seller.Dto seller)
        //{
        //    return new Crystal.Invoice.Component.Seller 
        //    {
        //        Name = seller.Name,
        //        Address = seller.Address,
        //        Liscence = seller.Liscence,
        //        Email = seller.Email,
        //        ContactNumber = seller.ContactNumber
        //    }; 
        //}

        //private Crystal.Invoice.Component.Buyer GetBuyer(Buyer.Dto buyer)
        //{
        //    return new Crystal.Invoice.Component.Buyer 
        //    { 
        //        Name = buyer.Name,
        //        Address = buyer.Address,
        //        Email = buyer.Email,
        //        ContactNumber = buyer.ContactNumber
        //    };
        //}

        //private List<BinAff.Core.Data> GetLineItem(List<LineItem.Dto> roomList)
        //{
        //    List<BinAff.Core.Data> lineItemList = new List<Data>();
        //    if (roomList != null && roomList.Count > 0)
        //    {
        //        foreach (LineItem.Dto lineItem in roomList)
        //        {
        //            lineItemList.Add(new Crystal.Invoice.Component.LineItem.Data 
        //            {
        //                Start = lineItem.startDate,
        //                End = lineItem.endDate,
        //                Description = lineItem.description,
        //                UnitRate = lineItem.unitRate,
        //                Count = lineItem.count,
        //                Total = lineItem.total
        //            });
        //        }
        //    }
        //    return lineItemList;
        //}
        
        //private List<BinAff.Core.Data> GetTaxation(List<Taxation.Dto> taxationList)
        //{
        //    List<BinAff.Core.Data> taxationDataList = new List<Data>();
        //    if (taxationList != null && taxationList.Count > 0)
        //    {
        //        foreach (Taxation.Dto dto in taxationList)
        //        {
        //            taxationDataList.Add(new Crystal.Invoice.Component.Taxation.Data 
        //            {
        //                Id = dto.Id,
        //                Name = dto.Name,
        //                Amount = dto.Amount,
        //                isPercentage = dto.isPercentage
        //            });
        //        }
        //    }
        //    return taxationDataList;
        //}

        //private List<BinAff.Core.Data> GetPayments(List<Payment.Dto> paymentList)
        //{
        //    List<BinAff.Core.Data> paymentDataList = new List<Data>();
        //    if (paymentList != null && paymentList.Count > 0)
        //    {
        //        foreach (Payment.Dto dto in paymentList)
        //        {
        //            paymentDataList.Add(new Crystal.Invoice.Component.Payment.Data 
        //            { 
        //                Id = dto.Id,
        //                Type = new Crystal.Invoice.Component.Payment.Type.Data{ Id = dto.Type.Id },
        //                CardNumber = dto.cardNumber,
        //                Remark = dto.remark,
        //                Amount = dto.amount,
        //            });
        //        }
        //    }
        //    return paymentDataList;
        //}
    }
}
