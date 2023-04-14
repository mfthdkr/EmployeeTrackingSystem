using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackingSystem.BusinessLayer.Services
{
    public class DepartmentService : Service<Department, DepartmentDto>, IDepartmantService
    {   
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IGenericRepository<Department> repository, IUnitOfWork unitOfWork, IMapper mapper, IDepartmentRepository departmentRepository) : base(repository, unitOfWork, mapper)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<CustomResponseDto<DepartmentCreateDto>> AddAsync(DepartmentCreateDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            await _departmentRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<DepartmentCreateDto>(entity);

            return CustomResponseDto<DepartmentCreateDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<DepartmentWithEmployeesDto>> GetSingleByIdWithEmployees(int id)
        {
            var entity = await _departmentRepository.Where(x => x.Id == id).Include(x => x.Employees).FirstOrDefaultAsync();
            var dto = _mapper.Map<DepartmentWithEmployeesDto>(entity);
            return CustomResponseDto<DepartmentWithEmployeesDto>.Success(StatusCodes.Status200OK,dto);
        }

        public async Task<CustomResponseDto<DepartmentWithPositionDto>> GetSingleByIdWithPositions(int id)
        {
            var entity = await _departmentRepository.Where(x => x.Id == id).Include(x => x.Positions).FirstOrDefaultAsync();
            var dto = _mapper.Map<DepartmentWithPositionDto>(entity);
            return CustomResponseDto<DepartmentWithPositionDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(DepartmentUpdateDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            _departmentRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
