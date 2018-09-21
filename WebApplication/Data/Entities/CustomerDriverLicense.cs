using System;

namespace WebApplication.Data.Entities
{
    public class CustomerDriverLicense
    {
        public string ID { get; set; }
        public char Class { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Restrictions { get; set; }
    }
}