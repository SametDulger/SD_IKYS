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
    public class TrainingParticipantService : ITrainingParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingParticipantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetAllAsync()
        {
            var participants = await _unitOfWork.TrainingParticipants.GetAllAsync();
            return participants.Select(MapToDto);
        }

        public async Task<TrainingParticipantDto?> GetByIdAsync(int id)
        {
            var participant = await _unitOfWork.TrainingParticipants.GetByIdAsync(id);
            return participant != null ? MapToDto(participant) : null;
        }

        public async Task<TrainingParticipantDto> CreateAsync(CreateTrainingParticipantDto createDto)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(createDto.TrainingId);
            if (training == null)
                throw new InvalidOperationException("Training not found");

            var employee = await _unitOfWork.Employees.GetByIdAsync(createDto.EmployeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            if (await _unitOfWork.TrainingParticipants.IsEmployeeRegisteredAsync(createDto.TrainingId, createDto.EmployeeId))
                throw new InvalidOperationException("Employee is already registered for this training");

            var participant = new TrainingParticipant
            {
                TrainingId = createDto.TrainingId,
                EmployeeId = createDto.EmployeeId,
                Status = "Registered",
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.TrainingParticipants.AddAsync(participant);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(participant);
        }

        public async Task<TrainingParticipantDto> UpdateAsync(int id, UpdateTrainingParticipantDto updateDto)
        {
            var participant = await _unitOfWork.TrainingParticipants.GetByIdAsync(id);
            if (participant == null)
                throw new InvalidOperationException("Training participant not found");

            participant.TrainingId = updateDto.TrainingId;
            participant.EmployeeId = updateDto.EmployeeId;
            participant.Status = updateDto.Status;
            participant.CompletionDate = updateDto.CompletionDate;
            participant.CertificateNumber = updateDto.CertificateNumber;
            participant.Notes = updateDto.Notes;
            participant.IsActive = updateDto.IsActive;
            participant.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.TrainingParticipants.UpdateAsync(participant);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(participant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var participant = await _unitOfWork.TrainingParticipants.GetByIdAsync(id);
            if (participant == null)
                return false;

            await _unitOfWork.TrainingParticipants.DeleteAsync(participant);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetByTrainingAsync(int trainingId)
        {
            var participants = await _unitOfWork.TrainingParticipants.GetByTrainingAsync(trainingId);
            return participants.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetByEmployeeAsync(int employeeId)
        {
            var participants = await _unitOfWork.TrainingParticipants.GetByEmployeeAsync(employeeId);
            return participants.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetByStatusAsync(string status)
        {
            var participants = await _unitOfWork.TrainingParticipants.GetByStatusAsync(status);
            return participants.Select(MapToDto);
        }

        public async Task<bool> IsEmployeeRegisteredAsync(int trainingId, int employeeId)
        {
            return await _unitOfWork.TrainingParticipants.IsEmployeeRegisteredAsync(trainingId, employeeId);
        }

        public async Task<TrainingParticipantDto> UpdateScoreAsync(int id, UpdateTrainingScoreDto scoreDto)
        {
            var participant = await _unitOfWork.TrainingParticipants.GetByIdAsync(id);
            if (participant == null)
                throw new InvalidOperationException("Training participant not found");

            participant.Score = scoreDto.Score;
            participant.Notes = scoreDto.Notes;
            participant.CompletionDate = scoreDto.CompletionDate ?? DateTime.UtcNow;
            participant.CertificateNumber = scoreDto.CertificateNumber;
            participant.Status = "Completed";
            participant.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.TrainingParticipants.UpdateAsync(participant);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(participant);
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetCompletedParticipantsAsync()
        {
            var participants = await _unitOfWork.TrainingParticipants.GetByStatusAsync("Completed");
            return participants.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetPendingParticipantsAsync()
        {
            var participants = await _unitOfWork.TrainingParticipants.GetByStatusAsync("Registered");
            return participants.Select(MapToDto);
        }

        public async Task<IEnumerable<TrainingParticipantDto>> GetHighScoreParticipantsAsync()
        {
            var participants = await _unitOfWork.TrainingParticipants.GetAllAsync();
            return participants
                .Where(p => p.Score.HasValue && p.Score >= 80)
                .Select(MapToDto)
                .OrderByDescending(p => p.Score);
        }

        private TrainingParticipantDto MapToDto(TrainingParticipant participant)
        {
            return new TrainingParticipantDto
            {
                Id = participant.Id,
                TrainingId = participant.TrainingId,
                TrainingTitle = participant.Training?.Title ?? string.Empty,
                EmployeeId = participant.EmployeeId,
                EmployeeName = participant.Employee != null ? $"{participant.Employee.FirstName} {participant.Employee.LastName}" : string.Empty,
                Status = participant.Status,
                Score = participant.Score,
                CompletionDate = participant.CompletionDate,
                CertificateNumber = participant.CertificateNumber,
                Notes = participant.Notes,
                IsActive = participant.IsActive
            };
        }
    }
} 