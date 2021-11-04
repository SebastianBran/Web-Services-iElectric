﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Services
{
    public class UserPlanService : IUserPlanService
    {
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserPlanService(IUserPlanRepository userPlanRepository, IUnitOfWork unitOfWork)
        {
            _userPlanRepository = userPlanRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<UserPlan>> ListAsync()
        {
            return await _userPlanRepository.ListAsync();
        }

        public async Task<IEnumerable<UserPlan>> ListByDateAsync(DateTime date)
        {
            return await _userPlanRepository.ListByDateAsync(date);
        }

        public async Task<IEnumerable<UserPlan>> ListByPlanIdAsync(int planId)
        {
            return await _userPlanRepository.ListByPlanIdAsync(planId);
        }

        public async Task<IEnumerable<UserPlan>> ListByUserIdAsync(int userId)
        {
            return await _userPlanRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserPlanResponse> AssignUserPlanAsync(int userId, int planId, DateTime date)
        {
            try
            {
                await _userPlanRepository.AssingUserPlan(userId, planId, date);
                await _unitOfWork.CompleteAsync();

                UserPlan userPlan = await _userPlanRepository.FindByUserIdDateAndPlanIdAsync(userId, planId, date);

                return new UserPlanResponse(userPlan);
            }
            catch (Exception ex)
            {
                return new UserPlanResponse($"An error ocurred while assigning User to Plan {ex.Message}");
            }
        }

        public async Task<UserPlanResponse> UnassignUserPlanAsync(int userId, int planId, DateTime date)
        {
            try
            {
                UserPlan userPlan = await _userPlanRepository.FindByUserIdDateAndPlanIdAsync(userId, planId, date);

                _userPlanRepository.UnassingUserPlan(userId, planId, date);
                await _unitOfWork.CompleteAsync();


                return new UserPlanResponse(userPlan);
            }
            catch (Exception ex)
            {
                return new UserPlanResponse($"An error ocurred while unassigning User to Plan {ex.Message}");
            }
        }
    }
}