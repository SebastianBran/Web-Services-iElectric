using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientResponse> DeleteAsync(long id)
        {
            var existingClient = await _clientRepository.FindByIdAsync(id);

            if (existingClient == null)
                return new ClientResponse("Client not found.");

            try
            {
                _clientRepository.Remove(existingClient);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while deleting the client: {e.Message}");
            }
        }

        public async Task<ClientResponse> GetByIdAsync(long id)
        {
            var existingClient = await _clientRepository.FindByIdAsync(id);

            if (existingClient == null)
                return new ClientResponse("Client not found.");

            return new ClientResponse(existingClient);
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _clientRepository.ListAsync();
        }

        public async Task<ClientResponse> SaveAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(client);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while saving the client: {e.Message}");
            }
        }
        public async Task<IEnumerable<Client>> ListByPlanIdAsync(int planId)
        {
            var userPlan = await _userPlanRepository.ListByPlanIdAsync(planId);
            var users = userPlan.Select(up=>up.Client).ToList();
            return users;
        }
        public async Task<ClientResponse> UpdateAsync(long id, Client client)
        {
            var existingClient = await _clientRepository.FindByIdAsync(id);

            if (existingClient == null)
                return new ClientResponse("Client not found.");

            existingClient.Names = client.Names;
            existingClient.LastNames = client.LastNames;
            existingClient.CellphoneNumber = client.CellphoneNumber;
            existingClient.Address = client.Address;
            existingClient.Email = client.Email;
            existingClient.Password = client.Password;

            try
            {
                _clientRepository.Update(existingClient);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while updating the client: {e.Message}");
            }
        }
    }
}
