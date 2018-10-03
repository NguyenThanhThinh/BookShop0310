namespace BookShop0310.Data
{
    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }
}