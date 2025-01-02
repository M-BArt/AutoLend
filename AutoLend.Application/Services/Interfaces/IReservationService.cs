using AutoLend.Domain.DataModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Application.Services.Interfaces {
    public interface IReservationService {
        Task Create( Customer customer );
        Task Delete( Guid customerId );
        Task Update( Customer customer );
        Task<IEnumerable<Customer?>> GetAll();
        Task<Customer?> GetById( Guid id );
    }
}
