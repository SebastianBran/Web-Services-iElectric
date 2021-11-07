using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class UserPlanRepository : BaseRepository, IUserPlanRepository
    {
        public UserPlanRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserPlan userPlan)
        {
            await _context.UserPlans.AddAsync(userPlan);
        }

        public async Task AssingUserPlan(int clientId, int planId, DateTime date)
        {
            UserPlan userPlan = await FindByUserIdDateAndPlanIdAsync(clientId, planId, date);
            if (userPlan == null)
            {
                userPlan = new UserPlan { ClientId = clientId, PlanId = planId, DateOfUpdate = date };
                await AddAsync(userPlan);
            }
        }

        public async Task<UserPlan> FindByUserIdDateAndPlanIdAsync(int clientId, int planId, DateTime date)
        {
            return await _context.UserPlans.FindAsync(clientId, planId, date);
        }

        public async Task<IEnumerable<UserPlan>> ListAsync()
        {
            return await _context.UserPlans
                .Include(up => up.Client)
                .Include(up => up.Plan)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPlan>> ListByDateAsync(DateTime date)
        {
            return await _context.UserPlans
                .Where(up => up.DateOfUpdate == date)
                .Include(up => up.Client)
                .Include(up => up.Plan)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPlan>> ListByPlanIdAsync(int planId)
        {
            return await _context.UserPlans
                .Where(up => up.PlanId == planId)
                .Include(up => up.Plan)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPlan>> ListByUserIdAsync(int clientId)
        {
            return await _context.UserPlans
                .Where(up => up.ClientId == clientId)
                .Include(up => up.Client)
                .ToListAsync();
        }

        public void Remove(UserPlan userPlan)
        {
            _context.UserPlans.Remove(userPlan);
        }

        public async void UnassingUserPlan(int clientId, int planId, DateTime date)
        {
            UserPlan userPlan = await FindByUserIdDateAndPlanIdAsync(clientId, planId, date);
            if (userPlan != null)
            {
                Remove(userPlan);
            }
        }
    }
}