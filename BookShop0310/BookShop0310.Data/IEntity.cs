namespace BookShop0310.Data
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
