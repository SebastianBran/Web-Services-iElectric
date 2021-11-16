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
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlanResponse> DeleteAsync(long id)
        {
            var existingPlan = await _planRepository.FindById(id);
            if (existingPlan == null)
            {
                return new PlanResponse("Plan not found");
            }
            try
            {
                _planRepository.Remove(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while deleting plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> GetByIdAsync(long id)
        {
            var existingPlan = await _planRepository.FindById(id);
            if (existingPlan == null)
            {
                return new PlanResponse("Plan not found");
            }
            return new PlanResponse(existingPlan);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.AddAsync(plan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(plan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while saving plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(long id, Plan plan)
        {
            var existingPlan = await _planRepository.FindById(id);
            if (existingPlan == null)
            {
                return new PlanResponse("Plan not found");
            }
            existingPlan.Name = plan.Name;
            existingPlan.Price = plan.Price;
            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while updating plan: {ex.Message}");
            }
        }
    }
}