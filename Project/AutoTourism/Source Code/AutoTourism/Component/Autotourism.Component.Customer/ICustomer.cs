using System;

namespace AutoTourism.Component.Customer
{
    public interface ICustomer
    {
        Crystal.Customer.Component.Data GetCustomerForReservation(Int64 reservationId);
    }
}
