using System;
using tasks.Models;

namespace tasks.Resources
{
    public class TaskResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Status Status { get; set; }
    }
}