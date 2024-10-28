using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface WorkshopInterface
    {
        Task<ResponseModel<List<WorkshopModel>>> GetAllWorkshops();
        Task<ResponseModel<WorkshopModel>> GetOneWorkshop( int id);
        Task<ResponseModel<WorkshopModel>> PostWorkshop( WorkshopModel workshop);
        Task<ResponseModel<WorkshopModel>> PutWorkshop( WorkshopModel workshop );
        Task<ResponseModel<WorkshopModel>> DeleteWorkshop( int id);
    }
}