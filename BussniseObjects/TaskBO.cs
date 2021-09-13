using System;
using tasks.Models;

namespace tasks.BussniseObjects
{
    public class TaskBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Status Status { get; set; } 
    }
}