using System.ComponentModel.DataAnnotations;

namespace Data.Entities.UserManagement
{
    public class Addresses : BaseAuditCode
    {
        public Guid AddressesId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required String Address { get; set; }

        [Required(ErrorMessage = "City is required.")]

        public string? City { get; set; }
        [Required(ErrorMessage = "State is required.")]

        public string? State { get; set; }


        [Required(ErrorMessage = "PostalCode is required.")]

        public string? PostalCode { get; set; }
    }
}
