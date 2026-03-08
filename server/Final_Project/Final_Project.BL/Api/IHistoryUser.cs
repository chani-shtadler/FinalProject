using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BL.Models;
using Final_Project.Dal.Api;

namespace Final_Project.BL.Api
{
    internal interface IHistoryUser
    {
        List<HistoryAppointments> appointmentsHistoryBL(int userId);
    }
}
