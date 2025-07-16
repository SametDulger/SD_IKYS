using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrainingDto>> GetAllAsync()
        {
            var trainings = await _unitOfWork.Trainings.GetAllAsync();
            return trainings.Select(MapToDto);
        }

        public async Task<TrainingDto> GetByIdAsync(int id)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(id);
            return training != null ? MapToDto(training) : null;
        }

        public async Task<TrainingDto> CreateAsync(CreateTrainingDto createTrainingDto)
        {
            var training = new Training
            {
                Title = createTrainingDto.Title,
                Description = createTrainingDto.Description,
                TrainingType = createTrainingDto.TrainingType,
                StartDate = createTrainingDto.StartDate,
                EndDate = createTrainingDto.EndDate,
                Trainer = createTrainingDto.Trainer,
                Location = createTrainingDto.Location,
                MaxParticipants = createTrainingDto.MaxParticipants,
                UserId = createTrainingDto.UserId,
                Status = "Planned",
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.Trainings.AddAsync(training);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(training);
        }

        public async Task<TrainingDto> UpdateAsync(int id, UpdateTrainingDto updateTrainingDto)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(id);
            if (training == null)
                throw new InvalidOperationException("Training not found");

            training.Title = updateTrainingDto.Title;
            training.Description = updateTrainingDto.Description;
            training.TrainingType = updateTrainingDto.TrainingType;
            training.StartDate = updateTrainingDto.StartDate;
            training.EndDate = updateTrainingDto.EndDate;
            training.Trainer = updateTrainingDto.Trainer;
            training.Location = updateTrainingDto.Location;
            training.MaxParticipants = updateTrainingDto.MaxParticipants;
            training.Status = updateTrainingDto.Status;
            training.UserId = updateTrainingDto.UserId;
            training.IsActive = updateTrainingDto.IsActive;
            training.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Trainings.UpdateAsync(training);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(training);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(id);
            if (training == null)
                return false;

            await _unitOfWork.Trainings.DeleteAsync(training);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TrainingDto>> GetByTypeAsync(string trainingType)
        {
            var trainings = await _unitOfWork.Trainings.GetByTypeAsync(trainingType);
            return trainings.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingDto>> GetByStatusAsync(string status)
        {
            var trainings = await _unitOfWork.Trainings.GetByStatusAsync(status);
            return trainings.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var trainings = await _unitOfWork.Trainings.GetByDateRangeAsync(startDate, endDate);
            return trainings.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingDto>> GetActiveTrainingsAsync()
        {
            var trainings = await _unitOfWork.Trainings.GetActiveTrainingsAsync();
            return trainings.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingDto>> GetByTrainerAsync(string trainer)
        {
            var trainings = await _unitOfWork.Trainings.GetByTrainerAsync(trainer);
            return trainings.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingDto>> GetUpcomingTrainingsAsync()
        {
            var trainings = await _unitOfWork.Trainings.GetAllAsync();
            var now = DateTime.UtcNow;
            return trainings
                .Where(t => t.StartDate > now && t.Status == "Planned")
                .Select(MapToDto)
                .OrderBy(t => t.StartDate);
        }

        public async Task<IEnumerable<TrainingDto>> GetCompletedTrainingsAsync()
        {
            var trainings = await _unitOfWork.Trainings.GetAllAsync();
            var now = DateTime.UtcNow;
            return trainings
                .Where(t => t.EndDate < now && t.Status == "Completed")
                .Select(MapToDto)
                .OrderByDescending(t => t.EndDate);
        }

        public async Task<IEnumerable<TrainingDto>> GetCancelledTrainingsAsync()
        {
            var trainings = await _unitOfWork.Trainings.GetByStatusAsync("Cancelled");
            return trainings.Select(MapToDto);
        }

        private TrainingDto MapToDto(Training training)
        {
            return new TrainingDto
            {
                Id = training.Id,
                Title = training.Title,
                Description = training.Description,
                TrainingType = training.TrainingType,
                StartDate = training.StartDate,
                EndDate = training.EndDate,
                Trainer = training.Trainer,
                Location = training.Location,
                MaxParticipants = training.MaxParticipants,
                Status = training.Status,
                UserId = training.UserId,
                UserName = training.User != null ? training.User.Username : null,
                IsActive = training.IsActive,
                ParticipantCount = training.Participants?.Count ?? 0
            };
        }
    }
} 