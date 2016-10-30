using System;

namespace Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }   
        public DateTime DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public ToDoItem(string text)
        {
            Id = Guid.NewGuid(); // Generates new unique identifier
            Text = text;
            IsCompleted = false;
            DateCreated = DateTime.Now; // Set creation date as current time
        }

        public void MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                DateCompleted = DateTime.Now;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ToDoItem temp = (ToDoItem) obj;
            return Id.Equals(temp.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}