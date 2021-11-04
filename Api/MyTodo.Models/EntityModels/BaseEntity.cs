using System;

namespace MyTodo.Models.EntityModels
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; private set; }
        
        protected void setUpdateAt()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void deleteMe()
        {
            this.DeletedAt = DateTime.UtcNow;
        }

        public void restoreMe()
        {
            this.DeletedAt = null;
        }
    }
}