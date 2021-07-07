using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
