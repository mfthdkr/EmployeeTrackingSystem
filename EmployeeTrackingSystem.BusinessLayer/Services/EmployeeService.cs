using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace EmployeeTrackingSystem.BusinessLayer.Services
{
    public class EmployeeService : Service<Employee, EmployeeDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepository, IAddressRepository addressRepository) : base(repository, unitOfWork, mapper)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
        }


        // Indate propertysini set ettik.
        public async Task<CustomResponseDto<EmployeeCreateDto>> AddAsync(EmployeeCreateDto dto)
        {

            var newEntity = _mapper.Map<Employee>(dto);
            newEntity.Indate = DateTime.Now;

            await _employeeRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<EmployeeCreateDto>(newEntity);

            return CustomResponseDto<EmployeeCreateDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<EmployeesWithDepartmentAndPositionDto>> GetSingleByIdWithDepartmentAndPosition(int id)
        {
            var entities = await _employeeRepository.GetEmployeesWithDepartmentAndPosition(id);
            var entity = entities.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<EmployeesWithDepartmentAndPositionDto>(entity);

            return CustomResponseDto<EmployeesWithDepartmentAndPositionDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<List<EmployeesWithDepartmentAndPositionDto>>> GetEmployeesWithDepartmentAndPositionByDepartment(int id)
        {
            var entity = await _employeeRepository.GetEmployeesWithDepartmentAndPositionByDepartment(id);
            var dto = _mapper.Map<List<EmployeesWithDepartmentAndPositionDto>>(entity);

            return CustomResponseDto<List<EmployeesWithDepartmentAndPositionDto>>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(EmployeeUpdateDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);

            _employeeRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveEmployeeAsync(int id)
        {
            if(_addressRepository.AnyAsync(x=>x.EmployeeId == id).Result)
            {   
                var addresses = _addressRepository.Where(x=>x.EmployeeId==id).ToList();
                foreach (var address in addresses)
                {
                    _addressRepository.Remove(await _addressRepository.GetByIdAsync(address.Id));
                }
            }
            var entity = await _employeeRepository.GetByIdAsync(id);
            _employeeRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
