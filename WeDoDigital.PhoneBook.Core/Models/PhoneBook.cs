using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeDoDigital.PhoneBook.Core.Models
{
    public class PhoneBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid")]
        [StringLength(13, MinimumLength = 10)]
        public string? MobileNumber { get; set; }
    }
}
