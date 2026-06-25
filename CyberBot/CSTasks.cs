using System;

namespace CyberBot
{
    public class CSTasks
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
