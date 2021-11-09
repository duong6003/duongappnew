using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Resources { get; set; }
        public Status Status { get; set; }
    }
}