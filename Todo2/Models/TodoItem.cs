using System;
using System.Collections.Generic;

#nullable disable

namespace Todo2.Models
{
    public partial class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
