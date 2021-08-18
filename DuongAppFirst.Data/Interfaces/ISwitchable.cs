using DuongAppFirst.Data.Enums;

namespace DuongAppFirst.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}