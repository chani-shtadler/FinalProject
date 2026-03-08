using Final_Project.Dal.Api;
using Final_Project.Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Dal.Servises
{
    internal class UserService : Api.IUserHistory
    {
        List<Appointment> IUserHistory.appointmentsHistory(int userId)
        {
            // Query the appointments table for the given userId and return the list
            using (var context = new models.dbmanager())
            {
                return context.Appointments.Where(a => a.UserId == userId).ToList();
            }
        }
    }
}
