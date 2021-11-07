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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IUnitOfWork unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AnnouncementResponse> DeleteAsync(long id)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);

            if (existingAnnouncement == null)
                return new AnnouncementResponse("Announcement not found.");

            try
            {
                _announcementRepository.Remove(existingAnnouncement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(existingAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while deleting the announcement: {e.Message}");
            }
        }

        public async Task<AnnouncementResponse> GetByIdAsync(long id)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);

            if (existingAnnouncement == null)
                return new AnnouncementResponse("Announcement not found.");

            return new AnnouncementResponse(existingAnnouncement);
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _announcementRepository.ListAsync();
        }

        public async Task<AnnouncementResponse> SaveAsync(Announcement announcement)
        {
            try
            {
                await _announcementRepository.AddAsync(announcement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(announcement);
            }
            catch (Exception e) 
            {
                return new AnnouncementResponse($"An error occurred while saving the announcement: {e.Message}");
            }
        }

        public async Task<AnnouncementResponse> UpdateAsync(long id, Announcement announcement)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);

            if (existingAnnouncement == null)
                return new AnnouncementResponse("Announcement not found.");

            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Description = announcement.Description;
            existingAnnouncement.Content = announcement.Content;
            existingAnnouncement.UrlToImage = announcement.UrlToImage;
            existingAnnouncement.TypeOfAnnouncement = announcement.TypeOfAnnouncement;
            existingAnnouncement.Visible = announcement.Visible;

            try
            {
                _announcementRepository.Update(existingAnnouncement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(existingAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while updating the announcement: {e.Message}");
            }
        }
    }
}
