namespace Maxim.Models.Entity
{
    public abstract class BaseAudiTableEntity:BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
