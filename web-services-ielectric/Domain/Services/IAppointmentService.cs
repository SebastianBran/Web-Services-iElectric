using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<AppointmentResponse> GetByIdAsync(long id);
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> UpdateAsync(long id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(long id);
    }
}