using System;
using System.Collections.Generic;
using System.Text;

namespace KegCleaningTimer.Models
{
    public class Timer
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public DateTime TimerLength { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

    }
}
