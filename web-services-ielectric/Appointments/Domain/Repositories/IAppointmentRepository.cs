using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment appointment);
        Task<Appointment> FindByIdAsync(long id);
        void Update(Appointment appointment);
        void Remove(Appointment appointment);
    }
}
