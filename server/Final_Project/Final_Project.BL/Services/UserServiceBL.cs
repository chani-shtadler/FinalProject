//using User;
using System;
using System.Collections.Generic;
using Final_Project.BL.Api;
using Final_Project.BL.Models;
using Final_Project.Dal.Servises;
//using Microsoft.AspNetCore.Mvc;

namespace Final_Project.BL.Services
{
    public class UserServiceBL : IHistoryUser
    {
        private readonly UserService _userServiceDal = new UserService();


        public List<HistoryAppointments> GetUserHistory(int userId)
        {
            // קריאה לפונקציה שאת יצרת ב-DAL
            var rawData = _userServiceDal.appointmentsHistory(userId);

            // שליחה לעיבוד לוגי (הפונקציה שכתבת עם הסינון)
            return ((IHistoryUser)this).appointmentsHistoryBL(rawData);
        }


        List<HistoryAppointments> IHistoryUser.appointmentsHistoryBL(List<Final_Project.Dal.models.Appointment> appointments)
        {
            var historyAppointments = new List<HistoryAppointments>();
            if (appointments == null) return historyAppointments;

            foreach (var appointment in appointments)
            {
                if (appointment == null) continue;

                // only include past appointments (compare dates only)
                if (appointment.AppointmentDate.Date < DateTime.Today)
                {
                    var history = new HistoryAppointments
                    {
                        userId = appointment.UserId,
                        fullName = appointment.User?.FullName ?? string.Empty,
                        phoneNumber = appointment.User?.PhoneNumber,
                        ServiceName = appointment.Service?.ServiceName ?? string.Empty,
                        Price = appointment.Service?.Price ?? 0m,
                        passedTime = (DateTime.Today - appointment.AppointmentDate.Date).Days
                    };

                    historyAppointments.Add(history);
                }
            }

            return historyAppointments;
        }
    }
}
