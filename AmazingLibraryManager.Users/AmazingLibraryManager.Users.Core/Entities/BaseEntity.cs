namespace AmazingLibraryManager.Users.Core.Entities
{
    public class BaseEntity
    {
       public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public BaseEntity(Guid id)
        {
            Id = id;
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}