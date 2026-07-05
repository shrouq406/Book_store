using System.ComponentModel.DataAnnotations;

namespace Book_store.Models
{
    public class RegisterVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
