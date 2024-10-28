using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface WorkshopInterface
    {
        Task<ServiceResponse<List<WorkshopModel>>> GetAllWorkshops();
        Task<ServiceResponse<WorkshopModel>> GetOneWorkshop( int id);
        Task<ServiceResponse<WorkshopModel>> PostWorkshop( WorkshopModel workshop);
        Task<ServiceResponse<WorkshopModel>> PutWorkshop( WorkshopModel workshop );
        Task<ServiceResponse<WorkshopModel>> DeleteWorkshop( int id);
    }
}