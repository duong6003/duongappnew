namespace DuongAppFirst.Data.Interfaces
{
    public interface IHasSeoMetadata<T>
    {
        T OwnerId { set; get; }
    }
}