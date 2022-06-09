using System;

namespace DTOs.Get
{
    public class PurchaseGetDTO
    {
        public string Description { get; set; }
        public string Number { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? BuyerId { get; set; }
        public DateTime? DateOfSelling { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
