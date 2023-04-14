using AutoMapper;
using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using EmployeeTrackingSystem.CoreLayer.Entities;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;

namespace EmployeeTrackingSystem.BusinessLayer.Services
{
    public class AddressService : Service<Address, AddressDto>, IAddressService
    {
        public AddressService(IGenericRepository<Address> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
