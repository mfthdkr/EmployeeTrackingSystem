using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackingSystem.BusinessLayer.Services
{
    public class PositonService : Service<Position, PositionDto>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public PositonService(IGenericRepository<Position> repository, IUnitOfWork unitOfWork, IMapper mapper, IPositionRepository positionRepository, IEmployeeRepository employeeRepository) : base(repository, unitOfWork, mapper)
        {
            _positionRepository = positionRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<CustomResponseDto<PositionWithEmployeesDto>> GetSingleByIdWithEmployees(int id)
        {
            var entity = await _positionRepository.Where(x => x.Id == id).Include(x => x.Employees).FirstOrDefaultAsync();
            var dto = _mapper.Map<PositionWithEmployeesDto>(entity);

            return CustomResponseDto<PositionWithEmployeesDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<PositionCreateDto>> AddAsync(PositionCreateDto dto)
        {
            var entity = _mapper.Map<Position>(dto);
            await _positionRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<PositionCreateDto>(entity);

            return CustomResponseDto<PositionCreateDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(PositionUpdateDto dto)
        {
            var entity = _mapper.Map<Position>(dto);
            _positionRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemovePositionAsync(int id)
        {
            if (_employeeRepository.AnyAsync(x => x.PositionId == id).Result)
            {
                var employees = _employeeRepository.Where(e => e.PositionId == id).ToList();
                foreach (var employee in employees)
                {
                    employee.PositionId = null;
                }
                await _unitOfWork.CommitAsync();
            }
            var entity = await _positionRepository.GetByIdAsync(id);
            _positionRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
