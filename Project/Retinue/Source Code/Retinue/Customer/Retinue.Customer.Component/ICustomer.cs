using System;

namespace Retinue.Customer.Component
{

    public interface ICustomer
    {

        Crystal.Customer.Component.Data GetCustomerForReservation(Int64 reservationId);

    }

}
