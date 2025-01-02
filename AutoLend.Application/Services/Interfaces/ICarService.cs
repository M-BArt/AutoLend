using AutoLend.Domain.DataModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Application.Services.Interfaces {
    public interface ICarService {
        Task CreateCar( Customer customer );
        Task DeleteCar( Guid customerId );
        Task UpdateCar( Customer customer );
        Task<IEnumerable<Customer?>> GetAllCars();
        Task<Customer?> GetCarById( Guid id );
    }
}
