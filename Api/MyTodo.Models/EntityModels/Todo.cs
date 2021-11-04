using System;

namespace MyTodo.Models.EntityModels
{
    public class Todo : BaseEntity
    {
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime? Expire { get; private set; } = null;

        public Todo(string title, bool done, DateTime? expire)
        {
            this.Title = title;
            this.Done = done;
            this.Expire = expire;
        }

        public void setTitle(string title)
        {
            this.Title = title;
            this.setUpdateAt();
        }

        public void setDone(bool done)
        {
            this.Done = done;
            this.setUpdateAt();
        }

        public void setExpire(DateTime? expire)
        {
            this.Expire = expire;
            this.setUpdateAt();
        }
    }
}