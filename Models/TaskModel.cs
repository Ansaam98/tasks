using System;

namespace tasks.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Status Status { get; set; }
    }
}