using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BL.Models;
using Final_Project.Dal.Api;

namespace Final_Project.BL.Api
{
    public interface IHistoryUser
    {
        List<HistoryAppointments> appointmentsHistoryBL(List<Final_Project.Dal.models.Appointment> appointments);
        List<HistoryAppointments> GetUserHistory(int userId);
    }
}
