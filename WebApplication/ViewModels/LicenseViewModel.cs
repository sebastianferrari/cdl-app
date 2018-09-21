using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class LicenseViewModel
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public char Class { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string State { get; set; }
        [MaxLength(500)]
        public string Restrictions { get; set; }
    }
}