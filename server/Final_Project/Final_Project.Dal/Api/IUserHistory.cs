using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Dal.Api
{
    public interface IUserHistory
    {
        List<models.Appointment> appointmentsHistory(int userId);
    }
}
