using System;

namespace DTOs.Get
{
    public class UserTypeGetDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
