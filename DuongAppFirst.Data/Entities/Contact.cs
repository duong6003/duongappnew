using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("Contacts")]
    public class Contact : DomainEntity<string>, ISwitchable
    {
        public Contact() { }

        public Contact(string id, string name, string phone, string email,
            string website, string address, string other, double? longtitude, double? latitude, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            Address = address;
            Other = other;
            Longitude = longtitude;
            Latitude = latitude;
            Status = status;
        }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public string Other { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public Status Status { get; set; }
    }
}