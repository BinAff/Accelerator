using System;

namespace AutoTourism.Customer.Facade.Report
{

    public class Dto : Vanilla.Report.Facade.Document.Dto
    {

        public DateTime CheckInDate { get; set; }
        public Int64 RoomCheckInId { get; set; }
        public Int64 ReservationId { get; set; }
        public Int64 CheckInStatusId { get; set; }
        public String InvoiceNumber { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int32 NoOfDays { get; set; }
        public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        public String Description { get; set; }
        public Int64 RoomCategoryId { get; set; }
        public Int64 RoomTypeId { get; set; }
        public Double Advance { get; set; }		

        public String Initial { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public String Email { get; set; }
        public String IdentityProofType { get; set; }
        public String IdentityProofName { get; set; }
        public String ContactNumber { get; set; }

        public String Name
        {
            get
            {
                String name = this.FirstName == null ? String.Empty : this.FirstName;
                name += String.IsNullOrEmpty(name) ? (String.IsNullOrEmpty(this.MiddleName) ? String.Empty : this.MiddleName) : " " + (String.IsNullOrEmpty(this.MiddleName) ? String.Empty : this.MiddleName);
                name += String.IsNullOrEmpty(name) ? (String.IsNullOrEmpty(this.LastName) ? String.Empty : this.LastName) : " " + (String.IsNullOrEmpty(this.LastName) ? String.Empty : this.LastName);
                return name;
            }
        }

    }

}
