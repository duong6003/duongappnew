using DuongAppFirst.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("AnnouncementUserpublics ")]
    public class AnnouncementUser : DomainEntity<int>
    {
        public string AnnouncementId { get; set; }
        public string UserId { get; set; }
        public bool? HasRead { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}