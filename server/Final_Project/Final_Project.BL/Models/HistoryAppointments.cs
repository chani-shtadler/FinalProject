using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.BL.Models
{
    public class HistoryAppointments
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public string? phoneNumber { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int passedTime { get; set; }
    }
}
