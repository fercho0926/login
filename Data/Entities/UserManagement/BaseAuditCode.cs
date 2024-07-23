using System.ComponentModel.DataAnnotations;

namespace Data.Entities.UserManagement
{
    public class BaseAuditCode
    {

        [Required(ErrorMessage = "CreatedDate is required.")]

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "CreatedBy is required.")]

        public required string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
